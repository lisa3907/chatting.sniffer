using Quiksoft.EasyMail.Parse;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using OdinSoft.LIB.Data;
using OdinSoft.LIB.Data.Collection;
using Sniffer.Proxy.CPacket;

namespace Sniffer.Proxy.Mail
{
    public class SmtpMail
    {
        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public SmtpMail()
        {
            const string licenceKey = "OdinSoft Inc  (Single Developer)/8202290F138938808F2E5117716068";
            Quiksoft.EasyMail.Parse.License.Key = licenceKey;
        }

        public SmtpMail(Queue p_syncQueue)
            : this()
        {
            if (p_syncQueue != null)
                m_syncQueue = p_syncQueue;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private Queue m_syncQueue = null;
        public Queue g_syncQueue
        {
            get
            {
                if (m_syncQueue == null)
                    m_syncQueue = Queue.Synchronized(new Queue());
                return m_syncQueue;
            }
        }

        private DataHelper m_dataHelper = null;
        private DataHelper g_dataHelper
        {
            get
            {
                if (m_dataHelper == null)
                    m_dataHelper = new DataHelper(MKindOfDatabase.MSSQL);

                return m_dataHelper;
            }
        }

        private DatParameters m_dbps = null;
        private DatParameters g_dbps
        {
            get
            {
                if (m_dbps == null)
                    m_dbps = new DatParameters();
                return m_dbps;
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public struct MailRecord
        {
            public Guid m_uniKey;
            public DateTime m_createTime;

            public bool m_istimeout;
            public bool m_isvalid;
            public bool m_iscompleted;
            public bool m_isaved;

            public uint m_msglen;
            public byte[] m_message;

            public string m_from;
            public string m_to;

            public string m_title;

            public SMTP_TYPE m_type;
            public string m_direction;
            public string m_command;
            public string m_response;

            public string m_sendipadrs;
            public ushort m_sendport;
            public string m_recvipadrs;
        }

        private SortedList m_unikeys = null;
        private SortedList g_unikeys
        {
            get
            {
                if (m_unikeys == null)
                    m_unikeys = new SortedList();

                return m_unikeys;
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private string GetMailAddress(AddressCollection p_address)
        {
            var _result = String.Empty;

            foreach (Address _adrs in p_address)
                _result += _adrs.EmailAddress + ";";

            return _result.TrimEnd(';');
        }

        private string SeekMessage(SPACKET_INTERNET p_internet)
        {
            string _direction = "C";
            string _ipadrs = p_internet.src_adrs;
            ushort _port = p_internet.src_port;

            if (p_internet.src_port == (ushort) TYPE_TCP_PORT.SMTP)
            {
                _direction = "S";
                _ipadrs = p_internet.dst_adrs;
                _port = p_internet.dst_port;
            }

            MailRecord _result = new MailRecord();

            string _seekey = String.Format("{0}:{1}", _ipadrs, _port);
            if (g_unikeys.Contains(_seekey) == false)
            {
                _result.m_uniKey = Guid.NewGuid();
                _result.m_createTime = DateTime.Now;

                _result.m_istimeout = false;
                _result.m_isvalid = true;
                _result.m_iscompleted = false;
                _result.m_isaved = false;

                _result.m_msglen = 0;
                _result.m_message = null;

                _result.m_from = String.Empty;
                _result.m_to = String.Empty;
                _result.m_title = String.Empty;

                _result.m_type = SMTP_TYPE.NULL;
                _result.m_command = String.Empty;

                if (_direction == "C")
                {
                    _result.m_sendipadrs = p_internet.src_adrs;
                    _result.m_sendport = p_internet.src_port;
                    _result.m_recvipadrs = p_internet.dst_adrs;
                }
                else
                {
                    _result.m_sendipadrs = p_internet.dst_adrs;
                    _result.m_sendport = p_internet.dst_port;
                    _result.m_recvipadrs = p_internet.src_adrs;
                }

                g_unikeys.Add(_seekey, _result);
            }
            else
            {
                _result = (MailRecord) g_unikeys[_seekey];
                _result.m_direction= _direction;

                g_unikeys[_seekey] = _result;
            }

            return _seekey;
        }

        private void PurgeMessage()
        {
            DateTime _filter = DateTime.Now;

            for (int i = g_unikeys.Count - 1 ; i >= 0 ; i--)
            {
                MailRecord _record = (MailRecord) g_unikeys.GetByIndex(i);

                TimeSpan _gap = _filter.Subtract(_record.m_createTime);
                if (_gap.Minutes > 30)
                    _record.m_istimeout = true;

                if (_record.m_isvalid == false || _record.m_istimeout == true || _record.m_iscompleted == true)
                {
                    this.WriteMessage(ref _record);
                    g_unikeys.RemoveAt(i);
                }
            }
        }

        private bool WriteMessage(ref MailRecord p_record)
        {
            var _result = false;

            if (p_record.m_isaved == false)
            {
                try
                {
                    if (p_record.m_message != null && p_record.m_message.Length > 0)
                    {
                        smtparse _parse = new smtparse(p_record.m_message);
                        p_record.m_title = _parse["subject"];
                        p_record.m_from = _parse["from"];
                        p_record.m_to = _parse["to"];

                        EmailMessage _emsg = new EmailMessage(new MemoryStream(p_record.m_message));

                        if (String.IsNullOrEmpty(p_record.m_title) == true)
                            p_record.m_title = _emsg.Subject;

                        if (String.IsNullOrEmpty(p_record.m_from) == true)
                            p_record.m_from = this.GetMailAddress(_emsg.From);

                        if (String.IsNullOrEmpty(p_record.m_to) == true)
                            p_record.m_to = this.GetMailAddress(_emsg.To);

                        string _sqlstr 
                                = "INSERT INTO TB_iEIP_MONITOR_SMTP " 
                                + "( "
                                + "     sender, "
                                + "     sendipadrs, "
                                + "     sendport, "
                                + "     receivers, "
                                + "     recvipadrs, "
                                + "     title, "
                                + "     sentime, "
                                + "     attach, " 
                                + "     content, "
                                + "     timeout, "
                                + "     validation, "
                                + "     completed, "
                                + "     protocol, "
                                + "     command, " 
                                + "     response "
                                + ") "
                                + "values "
                                + "( "
                                + "     @sender, "
                                + "     @sendipadrs, "
                                + "     @sendport, "
                                + "     @receivers, "
                                + "     @recvipadrs, "
                                + "     @title, "
                                + "     @sentime, "
                                + "     @attach, " 
                                + "     @content, "
                                + "     @timeout, "
                                + "     @validation, "
                                + "     @completed, "
                                + "     @protocol, "
                                + "     @command, " 
                                + "     @response "
                                + ") ";

                        g_dbps.Clear();

                        g_dbps.Add("@sender", SqlDbType.NVarChar, p_record.m_from);
                        g_dbps.Add("@sendipadrs", SqlDbType.NVarChar, p_record.m_sendipadrs);
                        g_dbps.Add("@sendport", SqlDbType.Decimal, p_record.m_sendport);
                        g_dbps.Add("@receivers", SqlDbType.NVarChar, p_record.m_to);
                        g_dbps.Add("@recvipadrs", SqlDbType.NVarChar, p_record.m_recvipadrs);
                        g_dbps.Add("@title", SqlDbType.NVarChar, p_record.m_title);
                        g_dbps.Add("@sentime", SqlDbType.DateTime, p_record.m_createTime);
                        g_dbps.Add("@attach", SqlDbType.Decimal, _emsg.Attachments.Count);
                        g_dbps.Add("@content", SqlDbType.Image, p_record.m_message);

                        g_dbps.Add("@timeout", SqlDbType.NVarChar, (p_record.m_istimeout ? "T" : "F"));
                        g_dbps.Add("@validation", SqlDbType.NVarChar, (p_record.m_isvalid ? "T" : "F"));
                        g_dbps.Add("@completed", SqlDbType.NVarChar, (p_record.m_iscompleted ? "T" : "F"));

                        g_dbps.Add("@protocol", SqlDbType.NVarChar, p_record.m_type.ToString());
                        g_dbps.Add("@command", SqlDbType.NVarChar, p_record.m_command);
                        g_dbps.Add("@response", SqlDbType.NVarChar, p_record.m_response);

                        if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                            _result = true;
                    }

                    p_record.m_isaved = true;
                }
                catch (System.Data.SqlClient.SqlException sx)
                {
                    string _error = String.Empty;
                    foreach (DatParameter _dp in g_dbps)
                    {
                        _error += String.Format("{0}({1}): ", _dp.Name, _dp.Type);
                        if (_dp.Type == SqlDbType.Decimal)
                        {
                            _error += Convert.ToDecimal(_dp.Value);
                        }
                        else if (_dp.Type == SqlDbType.Image)
                        {
                            _error += ((byte[]) _dp.Value).Length;
                        }
                        else if (_dp.Type == SqlDbType.DateTime)
                        {
                            _error += Convert.ToDateTime(_dp.Value).ToShortDateString();
                        }
                        else
                        {
                            _error += Convert.ToString(_dp.Value);
                        }

                        _error += Environment.NewLine;
                    }

                    _error 
                        += "LineNumber:" + sx.LineNumber
                        + "\r\nErrorNumber: " + sx.Number
                        + "\r\nServer: " + sx.Server
                        + "\r\nErrorCode: " + sx.ErrorCode
                        + "\r\nProcedure: " + sx.Procedure;

                    CPACKET_STRING.g_eventLog.WriteEntry(sx.ToString() + Environment.NewLine + _error);
                    Debug.WriteLine(sx.ToString());
                }
                catch (Exception ex)
                {
                    CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                    Debug.WriteLine(ex.ToString());
                }
            }

            return _result;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private void ProcessPacket(object p_packet)
        {
            PacketArrivedArgs _args = (PacketArrivedArgs) p_packet;

            try
            {
                string _seekey = this.SeekMessage(_args.m_internet);
                MailRecord _record = (MailRecord) g_unikeys[_seekey];

                if (_record.m_isvalid == true && _record.m_istimeout == false && _record.m_iscompleted == false)
                {
                    if (_record.m_direction == "C")
                    {
                        if (_record.m_command == "DATA")
                        {
                            int _clength = (int) _args.msg_buffer.Length;
                            int _offset = 0;

                            if (_record.m_message == null)
                            {
                                _record.m_message = new byte[_clength];
                                Array.Copy(_args.msg_buffer, 0, _record.m_message, _offset, _clength);
                            }
                            else
                            {
                                _offset = _record.m_message.Length;
                                Array.Resize<byte>(ref _record.m_message, _clength + _offset);
                                Array.Copy(_args.msg_buffer, 0, _record.m_message, _offset, _clength);
                            }
                        }
                        else
                        {
                            string _prevcmd = _record.m_command;

                            string[] _command = CPACKET_STRING.GetFirstLine(_args.msg_buffer, CPACKET_STRING.m_delimeter).Split(' ');
                            _record.m_command = _command[0].ToUpper();

                            if (_record.m_command == "HELO")
                            {
                                _record.m_type = SMTP_TYPE.SMTP;
                            }
                            else if (_record.m_command == "EHLO")
                            {
                                _record.m_type = SMTP_TYPE.ESMTP;
                            }
                            else if (_record.m_command == "MAIL")
                            {
                                //_record.m_from = this.GetEmailAddress(_command[1]);
                            }
                            else if (_record.m_command == "RCPT")
                            {
                                //_record.m_to += this.GetEmailAddress(_command[1]) + ";";
                            }
                            else if (_record.m_command == "DATA")
                            {
                                
                            }
                            else if (_record.m_command == "BDAT")
                            {
                                _record.m_command = "DATA";
                            }
                            else if (_record.m_command == "QUIT")
                            {
                                _record.m_iscompleted = true;
                            }
                            else
                            {
                                _record.m_command = _prevcmd;
                            }
                        }
                    }
                    else
                    {
                        string[] _response = CPACKET_STRING.GetFirstLine(_args.msg_buffer, CPACKET_STRING.m_delimeter).Split(' ');
                        _record.m_response = _response[0];

                        if (_record.m_command == "DATA" && _record.m_message != null)
                        {
                            _record.m_iscompleted = true;
                            this.WriteMessage(ref _record);
                        }
                    }

                    g_unikeys[_seekey] = _record;
                }

                this.PurgeMessage();
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private void Parser()
        {
            while (true)
            {
                lock (this.g_syncQueue)
                {
                    if (this.g_syncQueue.Count > 0)
                    {
                        object _popmsg = this.g_syncQueue.Dequeue();
                        this.ProcessPacket(_popmsg);
                    }
                }

                Thread.Sleep(10);
            }
        }

        public void Start()
        {
            Thread _parsing = new Thread(Parser);
            _parsing.IsBackground = true;
            _parsing.Start();
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
    }
}
