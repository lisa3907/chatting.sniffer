using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Sniffer.Proxy.CPacket;
using OdinSoft.LIB.Data;

namespace Sniffer.Proxy.Msn
{
    public class MSN
    {
        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public MSN()
        {
        }

        public MSN(Queue p_syncQueue)
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

        private OdinSoft.LIB.Data.DataHelper m_dataHelper = null;
        private OdinSoft.LIB.Data.DataHelper g_dataHelper
        {
            get
            {
                if (m_dataHelper == null)
                    m_dataHelper = new OdinSoft.LIB.Data.DataHelper(MKindOfDatabase.MSSQL);

                return m_dataHelper;
            }
        }

        private OdinSoft.LIB.Data.Collection.DatParameters m_dbps = null;
        private OdinSoft.LIB.Data.Collection.DatParameters g_dbps
        {
            get
            {
                if (m_dbps == null)
                    m_dbps = new OdinSoft.LIB.Data.Collection.DatParameters();
                return m_dbps;
            }
        }

        private static Regex m_regex = null;
        private static Regex g_regex
        {
            get
            {
                if (m_regex == null)
                    m_regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

                return m_regex;
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        /*----------------------------------------------------------------------------------------------------------
        def read_buffer(self):
            lines = String.split(self.inbuffer, '\r\n')
            if len(lines) < 2:
                return
            words = String.split(lines[0])
            if self.inbuffer[:3] in ['MSG', 'NOT']: # Incoming payload commands
                length = int(words[3])
                remaining_lines = String.join(lines[1:], '\r\n')
                if len(remaining_lines) >= length:
                    self.inbuffer = self.inbuffer[(len(lines[0]) + 2 + length):]
                    self.cmd_handler(lines[0] + '\r\n' + remaining_lines[:length])
                else:
                    return 0
            else:
                self.inbuffer = self.inbuffer[(len(lines[0]) + 2):]
                self.cmd_handler(lines[0])
            self.read_buffer()
        ----------------------------------------------------------------------------------------------------------*/
        private SortedList m_ipList = null;
        private SortedList g_ipList
        {
            get
            {
                if (m_ipList == null)
                {
                    m_ipList = new SortedList();
                    LoadUserInfo(ref m_ipList);
                }

                return m_ipList;
            }
        }

        private string GetMailAdrs(string p_direction, SPACKET_INTERNET p_internet)
        {
            var _result = String.Empty;

            if (p_direction == "S")
            {
                string _ipadrs = p_internet.src_adrs;
                if (p_internet.src_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                    _ipadrs += String.Format(":{0}-{1}:{2}", p_internet.src_port, p_internet.dst_adrs, p_internet.dst_port);

                if (g_ipList.Contains(_ipadrs) == true)
                    _result = g_ipList[_ipadrs].ToString();
            }
            else
            {
                string _ipadrs = p_internet.dst_adrs;
                if (p_internet.dst_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                    _ipadrs += String.Format(":{0}-{1}:{2}", p_internet.dst_port, p_internet.src_adrs, p_internet.src_port);

                if (g_ipList.Contains(_ipadrs) == true)
                    _result = g_ipList[_ipadrs].ToString();
            }

            return _result;
        }

        private string GetIPAdrs(string p_mailadrs)
        {
            var _result = String.Empty;

            if (g_ipList.ContainsValue(p_mailadrs) == true)
            {
                int _index = g_ipList.IndexOfValue(p_mailadrs);
                _result = g_ipList.GetKey(_index).ToString();

                if (_result.IndexOf(':') > 0)
                    _result = String.Empty;
            }

            return _result;
        }

        private void PutMailAdrs(SPACKET_INTERNET p_internet, string p_mailadrs)
        {
            var _ipadrs = p_internet.src_adrs;
            if (p_internet.src_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                _ipadrs += String.Format(":{0}-{1}:{2}", p_internet.src_port, p_internet.dst_adrs, p_internet.dst_port);

            if (g_ipList.Contains(_ipadrs) == false)
            {
                g_ipList.Add(_ipadrs, p_mailadrs);
            }
            else
            {
                if (g_ipList[_ipadrs].ToString() != p_mailadrs)
                    g_ipList[_ipadrs] = p_mailadrs;
            }
        }

        private void PutMailAdrs(string p_ipadrs, string p_mailadrs)
        {
            if (g_ipList.Contains(p_ipadrs) == false)
            {
                g_ipList.Add(p_ipadrs, p_mailadrs);
            }
            else
            {
                if (g_ipList[p_ipadrs].ToString() != p_mailadrs)
                    g_ipList[p_ipadrs] = p_mailadrs;
            }
        }

        private void RmvMailAdrs(SPACKET_INTERNET p_internet)
        {
            var _ipadrs = p_internet.src_adrs;
            if (p_internet.src_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                _ipadrs += String.Format(":{0}-{1}:{2}", p_internet.src_port, p_internet.dst_adrs, p_internet.dst_port);

            if (g_ipList.Contains(_ipadrs) == true)
            {
                g_ipList.Remove(_ipadrs);
            }
        }

        private void RmvMailAdrs(string p_mailadrs)
        {
            while (g_ipList.ContainsValue(p_mailadrs) == true)
            {
                int _index = g_ipList.IndexOfValue(p_mailadrs);
                g_ipList.RemoveAt(_index);
            }
        }

        private bool IsEmailAdrs(string p_email)
        {
            var _result = false;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
            if (re.IsMatch(p_email))
                _result = true;

            return _result;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private bool SaveGroupList(string p_mailadrs, string p_groupid, string p_groupnm)
        {
            var _result = false;

            try
            {
                var _sqlstr 
                        = "IF EXISTS (SELECT mailadrs, groupid FROM TB_iEIP_MONITOR_GROUP "
                        + "     WHERE mailadrs=@mailadrs AND groupid=@groupid) "
                        + "BEGIN "
                        + "     UPDATE TB_iEIP_MONITOR_GROUP "
                        + "        SET grpname = @grpname, detect = @detect "
                        + "      WHERE mailadrs = @mailadrs AND groupid=@groupid "
                        + "END ELSE "
                        + "BEGIN "
                        + "     INSERT INTO TB_iEIP_MONITOR_GROUP "
                        + "     ( "
                        + "         mailadrs, groupid, grpname, detect "
                        + "     ) "
                        + "     values "
                        + "     ( "
                        + "         @mailadrs, @groupid, @grpname, @detect "
                        + "     ) "
                        + "END";

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@groupid", SqlDbType.NVarChar, p_groupid);
                    g_dbps.Add("@grpname", SqlDbType.NVarChar, p_groupnm);
                    g_dbps.Add("@detect", SqlDbType.DateTime, DateTime.Now);
                }

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                    _result = true;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool RemoveGroupList(string p_mailadrs, string p_groupid)
        {
            var _result = false;

            try
            {
                var _sqlstr 
                        = "DELETE TB_iEIP_MONITOR_GROUP "
                        + "WHERE mailadrs=@mailadrs AND groupid=@groupid";

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@groupid", SqlDbType.NVarChar, p_groupid);
                }

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                    _result = true;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool LoadUserInfo(ref SortedList p_srtList)
        {
            var _result = false;

            try
            {
                string _sqlstr
                    = "SELECT mailadrs, ipadrs FROM TB_iEIP_MONITOR_USRS "
                    + " WHERE ISNULL(ipadrs,'')!=''";

                DataSet _data = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr);

                foreach (DataRow _dr in _data.Tables[0].Rows)
                {
                    if (p_srtList.ContainsKey(_dr["ipadrs"].ToString()) == false)
                        p_srtList.Add(_dr["ipadrs"].ToString(), _dr["mailadrs"].ToString());
                }
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool SaveUserInfo(string p_mailadrs, string p_ipadrs, string p_nick)
        {
            var _result = false;

            try
            {
                var _sqlstr = String.Empty;

                if (String.IsNullOrEmpty(p_ipadrs) == false)
                {
                    _sqlstr 
                        = "IF EXISTS (SELECT mailadrs FROM TB_iEIP_MONITOR_USRS WHERE mailadrs = @mailadrs) "
                        + "BEGIN "
                        + "     UPDATE TB_iEIP_MONITOR_USRS "
                        + "        SET ipadrs = @ipadrs, nick = @nick, detect = @detect "
                        + "      WHERE mailadrs = @mailadrs "
                        + "END ELSE "
                        + "BEGIN "
                        + "     INSERT INTO TB_iEIP_MONITOR_USRS "
                        + "     ( "
                        + "         mailadrs, ipadrs, nick, detect "
                        + "     ) "
                        + "     values "
                        + "     ( "
                        + "         @mailadrs, @ipadrs, @nick, @detect "
                        + "     ) "
                        + "END";
                }
                else
                {
                    _sqlstr 
                        = "IF EXISTS (SELECT mailadrs FROM TB_iEIP_MONITOR_USRS WHERE mailadrs = @mailadrs) "
                        + "BEGIN "
                        + "     UPDATE TB_iEIP_MONITOR_USRS "
                        + "        SET nick = @nick, detect = @detect "
                        + "      WHERE mailadrs = @mailadrs "
                        + "END ELSE "
                        + "BEGIN "
                        + "     INSERT INTO TB_iEIP_MONITOR_USRS "
                        + "     ( "
                        + "         mailadrs, nick, detect "
                        + "     ) "
                        + "     values "
                        + "     ( "
                        + "         @mailadrs, @nick, @detect "
                        + "     ) "
                        + "END";
                }

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@ipadrs", SqlDbType.NVarChar, p_ipadrs);
                    g_dbps.Add("@nick", SqlDbType.NVarChar, p_nick);
                    g_dbps.Add("@detect", SqlDbType.DateTime, DateTime.Now);
                }

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                {
                    _sqlstr
                        = "UPDATE TB_iEIP_MONITOR_USRS "
                        + "SET ipadrs=b.sendipadrs "
                        + "FROM TB_iEIP_MONITOR_USRS a, TB_iEIP_MONITOR_MSGS b "
                        + "WHERE ISNULL(ipadrs,'')='' "
                        + "AND a.mailadrs=b.sender AND b.sendport!=@msnport "
                        + "AND a.mailadrs=@mailadrs "
                        + Environment.NewLine

                        + "UPDATE TB_iEIP_MONITOR_USRS "
                        + "SET ipadrs=b.recvipadrs "
                        + "FROM TB_iEIP_MONITOR_USRS a, TB_iEIP_MONITOR_MSGS b "
                        + "WHERE ISNULL(ipadrs,'')='' "
                        + "AND a.mailadrs=b.receiver AND b.recvport!=@msnport "
                        + "AND a.mailadrs=@mailadrs";

                    g_dbps.Add("@msnport", SqlDbType.Int, TYPE_TCP_PORT.MSNMSGR);

                    if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                        _result = true;
                }
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool SaveBuddyList(string p_mailadrs, string p_buddymail, string p_buddynick)
        {
            var _result = false;

            try
            {
                string _sqlstr
                        = "IF EXISTS (SELECT mailadrs, buddymail FROM TB_iEIP_MONITOR_BUDDY "
                        + "     WHERE mailadrs=@mailadrs AND buddymail=@buddymail) "
                        + "BEGIN "
                        + "     UPDATE TB_iEIP_MONITOR_BUDDY "
                        + "        SET buddynick = @buddynick, detect = @detect "
                        + "      WHERE mailadrs = @mailadrs AND buddymail=@buddymail "
                        + "END ELSE "
                        + "BEGIN "
                        + "     INSERT INTO TB_iEIP_MONITOR_BUDDY "
                        + "     ( "
                        + "         mailadrs, buddymail, buddynick, detect "
                        + "     ) "
                        + "     values "
                        + "     ( "
                        + "         @mailadrs, @buddymail, @buddynick, @detect "
                        + "     ) "
                        + "END";

                g_dbps.Clear();

                g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                g_dbps.Add("@buddymail", SqlDbType.NVarChar, p_buddymail);
                g_dbps.Add("@buddynick", SqlDbType.NVarChar, p_buddynick);
                g_dbps.Add("@detect", SqlDbType.DateTime, DateTime.Now);

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                    _result = true;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool SaveBuddyList(
            string p_mailadrs, string p_buddymail, string p_buddynick, string p_groupid, string p_buddyid, string p_presence
            )
        {
            var _result = false;

            try
            {
                string _sqlstr
                        = "IF EXISTS (SELECT mailadrs, buddymail FROM TB_iEIP_MONITOR_BUDDY "
                        + "     WHERE mailadrs=@mailadrs AND buddymail=@buddymail) "
                        + "BEGIN "
                        + "     UPDATE TB_iEIP_MONITOR_BUDDY "
                        + "        SET buddyid = @buddyid, buddynick = @buddynick, detect = @detect, "
                        + "             groupid = @groupid, presence = @presence "
                        + "      WHERE mailadrs = @mailadrs AND buddymail=@buddymail "
                        + "END ELSE "
                        + "BEGIN "
                        + "     INSERT INTO TB_iEIP_MONITOR_BUDDY "
                        + "     ( "
                        + "         mailadrs, buddymail, buddyid, buddynick, groupid, presence, detect "
                        + "     ) "
                        + "     values "
                        + "     ( "
                        + "         @mailadrs, @buddymail, @buddyid, @buddynick, @groupid, @presence, @detect "
                        + "     ) "
                        + "END";

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@buddyid", SqlDbType.NVarChar, p_buddyid);
                    g_dbps.Add("@groupid", SqlDbType.NVarChar, p_groupid);
                    g_dbps.Add("@buddymail", SqlDbType.NVarChar, p_buddymail);
                    g_dbps.Add("@buddynick", SqlDbType.NVarChar, p_buddynick);
                    g_dbps.Add("@presence", SqlDbType.Decimal, Convert.ToInt32(p_presence));
                    g_dbps.Add("@detect", SqlDbType.DateTime, DateTime.Now);
                }

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                    _result = true;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private DataSet ReadBuddyList(string p_mailadrs, string p_buddyid)
        {
            var _result = new DataSet();

            try
            {
                var _sqlstr = ""
                        + "SELECT * FROM TB_iEIP_MONITOR_BUDDY "
                        + " WHERE mailadrs=@mailadrs AND buddyid=@buddyid";

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@buddyid", SqlDbType.NVarChar, p_buddyid);
                }

                _result = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        private bool RemoveBuddyList(string p_mailadrs, string p_userid, string p_groupid)
        {
            var _result = false;

            try
            {
                string _sqlstr
                        = "DELETE TB_iEIP_MONITOR_BUDDY "
                        + "WHERE mailadrs=@mailadrs "
                        + "  AND buddyid=@buddyid AND groupid=@groupid";

                g_dbps.Clear();
                {
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, p_mailadrs);
                    g_dbps.Add("@buddyid", SqlDbType.NVarChar, p_userid);
                    g_dbps.Add("@groupid", SqlDbType.NVarChar, p_groupid);
                }

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                    _result = true;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }


        private bool SaveMessage(SPACKET_INTERNET p_internet, string p_message)
        {
            var _result = false;

            try
            {
                string _sqlstr
                    = "INSERT INTO TB_iEIP_MONITOR_MSGS "
                    + "( "
                    + "   sender, sendipadrs, sendport, receiver, recvipadrs, recvport, sentime, content "
                    + ") "
                    + "values "
                    + "( "
                    + "   @sender, @sendipadrs, @sendport, @receiver, @recvipadrs, @recvport, @sentime, @content "
                    + ")";

                g_dbps.Clear();

                g_dbps.Add("@sender", SqlDbType.NVarChar, GetMailAdrs("S", p_internet));
                g_dbps.Add("@sendipadrs", SqlDbType.NVarChar, p_internet.src_adrs);
                g_dbps.Add("@sendport", SqlDbType.Int, p_internet.src_port);

                g_dbps.Add("@receiver", SqlDbType.NVarChar, GetMailAdrs("R", p_internet));
                g_dbps.Add("@recvipadrs", SqlDbType.NVarChar, p_internet.dst_adrs);
                g_dbps.Add("@recvport", SqlDbType.Int, p_internet.dst_port);

                g_dbps.Add("@sentime", SqlDbType.DateTime, DateTime.Now);
                g_dbps.Add("@content", SqlDbType.NText, p_message);

                if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                {
                    _sqlstr
                        = "UPDATE TB_iEIP_MONITOR_MSGS "
                        + "SET sender=b.mailadrs "
                        + "FROM TB_iEIP_MONITOR_MSGS a, TB_iEIP_MONITOR_USRS b "
                        + "WHERE ISNULL(a.sender, '') = '' "
                        + "AND a.sendipadrs=b.ipadrs "
                        + "AND a.sendipadrs=@sendipadrs "
                        + Environment.NewLine

                        + "UPDATE TB_iEIP_MONITOR_MSGS "
                        + "SET receiver=b.mailadrs "
                        + "FROM TB_iEIP_MONITOR_MSGS a, TB_iEIP_MONITOR_USRS b "
                        + "WHERE ISNULL(a.receiver, '') = ''  "
                        + "AND a.recvipadrs=b.ipadrs "
                        + "AND a.recvipadrs=@recvipadrs "
                        + Environment.NewLine

                        + "UPDATE TB_iEIP_MONITOR_MSGS "
                        + "SET sendernick=b.nick "
                        + "FROM TB_iEIP_MONITOR_MSGS a, TB_iEIP_MONITOR_USRS b "
                        + "WHERE ISNULL(a.sendernick, '') = ''  "
                        + "AND a.sender=b.mailadrs "
                        + "AND a.sender=@sender";

                    if (g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps) > 0)
                        _result = true;
                }
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
            }

            return _result;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private void ProcessMessage(SPACKET_INTERNET p_internet, string p_command, byte[] p_buffer)
        {
            string[] _lines = CPACKET_STRING.GetSplitLines(p_buffer, CPACKET_STRING.m_delimeter, 4);

            if (p_command == "MSG")
            {
                if (_lines.Length >= 4)
                {
                    string[] _words = _lines[2].Split(' ');
                    if (_words[1].StartsWith("text") == true)
                    {
                        string[] _content = _words[1].Split('/');
                        if (_content[1].StartsWith("plain") == true)
                        {
                            string[] _charset = _words[2].Split('=');
                            Encoding _encoder = Encoding.GetEncoding(_charset[1]);

                            string[] _typingUser = _lines[0].Split(' ');
                            if (g_regex.IsMatch(_typingUser[1]) == true)
                            {
                                PutMailAdrs(p_internet, _typingUser[1]);

                                string _nick = System.Web.HttpUtility.UrlDecode(_typingUser[2]);
                                string _ipadrs = GetIPAdrs(_typingUser[1]);
                                SaveUserInfo(_typingUser[1], _ipadrs, _nick);
                            }

                            string _message = _encoder.GetString(CPACKET_STRING.GetSelectedLine(p_buffer, CPACKET_STRING.m_delimeter, 6));
                            this.SaveMessage(p_internet, _message);
                        }
                        else if (_content[1].StartsWith("x-msmsgscontrol") == true)
                        {
                            string[] _typingUser = _lines[0].Split(' ');
                            if (g_regex.IsMatch(_typingUser[1]) == true)
                            {
                                PutMailAdrs(p_internet, _typingUser[1]);

                                string _nick = System.Web.HttpUtility.UrlDecode(_typingUser[2]);
                                string _ipadrs = GetIPAdrs(_typingUser[1]);
                                SaveUserInfo(_typingUser[1], _ipadrs, _nick);
                            }
                        }
                    }
                    else if (_words[1].StartsWith("application") == true)
                    {
                        string[] _content = _words[1].Split('/');
                        if (_content[1].StartsWith("x-msnmsgrp2p") == true)
                        {
                            string[] _typingUser = _lines[0].Split(' ');
                            if (g_regex.IsMatch(_typingUser[1]) == true)
                            {
                                string _nick = System.Web.HttpUtility.UrlDecode(_typingUser[2]);
                                string _ipadrs = GetIPAdrs(_typingUser[1]);
                                SaveUserInfo(_typingUser[1], _ipadrs, _nick);
                            }
                        }
                    }
                }
            }
            else if (p_command == "USR")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 2)
                {
                    if (_cmds[2] == "OK")
                    {
                        if (_cmds.Length > 4)
                        {
                            PutMailAdrs(p_internet.dst_adrs, _cmds[3]);

                            string _nick = System.Web.HttpUtility.UrlDecode(_cmds[4]);
                            SaveUserInfo(_cmds[3], p_internet.dst_adrs, _nick);
                        }
                    }
                    else if (g_regex.IsMatch(_cmds[2]) == true)
                    {
                        PutMailAdrs(p_internet, _cmds[2]);
                    }
                }
            }
            else if (p_command == "ADC")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 4)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                    {
                        string _bmail = "", _bnick = "", _usrid = "", _grpid = "", _presence = "0";

                        string[] _words = _cmds[3].Split('=');
                        if (_words[0] == "N")
                        {
                            if (_cmds.Length > 5)
                            {
                                _bmail = _words[1];

                                _words = _cmds[4].Split('=');
                                _bnick = System.Web.HttpUtility.UrlDecode(_words[1]);

                                _words = _cmds[5].Split('=');
                                _usrid = _words[1];

                                SaveBuddyList(_mailadrs, _bmail, _bnick, _grpid, _usrid, _presence);
                            }
                        }
                        else
                        {
                            _words = _cmds[3].Split('=');
                            _usrid = _words[1];

                            _grpid = _cmds[4];

                            DataSet _ds = ReadBuddyList(_mailadrs, _usrid);
                            if (_ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[0].Rows[0];

                                _bmail = _dr["buddymail"].ToString();
                                _bnick = _dr["buddynick"].ToString();
                                _presence = _dr["presence"].ToString();

                                SaveBuddyList(_mailadrs, _bmail, _bnick, _grpid, _usrid, _presence);
                            }
                        }
                    }
                }
            }
            else if (p_command == "REM")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 4)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                        RemoveBuddyList(_mailadrs, _cmds[3], _cmds[4]);
                }
            }
            else if (p_command == "ANS")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 2)
                {
                    if (g_regex.IsMatch(_cmds[2]) == true)
                        PutMailAdrs(p_internet, _cmds[2]);
                }
            }
            else if (p_command == "NLN")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 3)
                {
                    if (g_regex.IsMatch(_cmds[2]) == true)
                    {
                        string _mailadrs = GetMailAdrs("R", p_internet);
                        if (g_regex.IsMatch(_mailadrs) == true)
                        {
                            string _bnick = System.Web.HttpUtility.UrlDecode(_cmds[3]);
                            SaveBuddyList(_mailadrs, _cmds[2], _bnick);
                        }
                    }
                }
            }
            else if (p_command == "LSG")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 2)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                        SaveGroupList(_mailadrs, _cmds[2], _cmds[1]);
                }
            }
            else if (p_command == "RMG")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 2)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                        RemoveGroupList(_mailadrs, _cmds[2]);
                }
            }
            else if (p_command == "REG")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 3)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                    {
                        RemoveGroupList(_mailadrs, _cmds[2]);
                        SaveGroupList(_mailadrs, _cmds[2], _cmds[3]);
                    }
                }
            }
            else if (p_command == "ADG")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 3)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                        SaveGroupList(_mailadrs, _cmds[3], _cmds[2]);
                }
            }
            else if (p_command == "LST")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 5)
                {
                    string _mailadrs = GetMailAdrs("R", p_internet);
                    if (g_regex.IsMatch(_mailadrs) == true)
                    {
                        string _bmail = _cmds[1];
                        string _bnick = _cmds[2];
                        string _usrid = _cmds[3];
                        string _lstno = _cmds[4];
                        string _grpid = _cmds[5];

                        string[] _words = _bmail.Split('=');
                        if (_words.Length > 0)
                            _bmail = _words[_words.Length - 1];

                        _words = _bnick.Split('=');
                        if (_words.Length > 0)
                            _bnick = _words[_words.Length - 1];
                        _bnick = System.Web.HttpUtility.UrlDecode(_bnick);

                        _words = _usrid.Split('=');
                        if (_words.Length > 0)
                            _usrid = _words[_words.Length - 1];

                        _words = _grpid.Split('=');
                        if (_words.Length > 0)
                            _grpid = _words[_words.Length - 1];

                        if (g_regex.IsMatch(_bmail) == true)
                            SaveBuddyList(_mailadrs, _bmail, _bnick, _grpid, _usrid, _lstno);
                    }
                }
            }
            else if (p_command == "JOI")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 2)
                {
                    if (g_regex.IsMatch(_cmds[1]) == true)
                    {
                        PutMailAdrs(p_internet, _cmds[1]);

                        string _nick = System.Web.HttpUtility.UrlDecode(_cmds[2]);
                        string _ipadrs = GetIPAdrs(_cmds[1]);
                        SaveUserInfo(_cmds[1], _ipadrs, _nick);
                    }
                }
            }
            else if (p_command == "FLN")
            {
                string[] _cmds = _lines[0].Split(' ');
                if (_cmds.Length > 1)
                {
                    if (g_regex.IsMatch(_cmds[1]) == true)
                        RmvMailAdrs(_cmds[1]);
                }
            }
            else if (p_command == "BYE" || p_command == "OUT")
            {
                RmvMailAdrs(p_internet);
            }
        }

        private void ProcessPacket(object p_packet)
        {
            PacketArrivedArgs _args = (PacketArrivedArgs)p_packet;

            try
            {
                int _tlength = (int)_args.msg_buffer.Length;
                int _toffset = 0;

                while (_tlength > _toffset)
                {
                    int _clength = _tlength - _toffset;
                    byte[] _msgbuff = new byte[_clength];
                    Array.Copy(_args.msg_buffer, _toffset, _msgbuff, 0, _clength);

                    string _message = CPACKET_STRING.GetFirstLine(_msgbuff, CPACKET_STRING.m_delimeter);
                    string[] _words = _message.Split(' ');

                    _args.m_command = _words[0];
                    if (_args.m_command == "MSG")
                    {
                        int _length = 0;
                        for (int i = 0; i < _msgbuff.Length; i++)
                        {
                            if (_msgbuff[i] == CPACKET_STRING.m_delimeter[0])
                            {
                                byte[] _lenbuff = new byte[_length];
                                Array.Copy(_msgbuff, _lenbuff, _length);

                                if (_words.Length < 4)
                                {
                                    _length = _clength;
                                    break;
                                }

                                _length += Convert.ToInt32(_words[3]) + 2;
                                if (_length > _clength)
                                    _length = _clength;
                                break;
                            }

                            _length++;
                        }

                        byte[] _buffer = new byte[_length];
                        Array.Copy(_msgbuff, _buffer, _length);

                        this.ProcessMessage(_args.m_internet, _args.m_command, _buffer);
                        _toffset += _length;
                    }
                    else
                    {
                        this.ProcessMessage(_args.m_internet, _args.m_command, _args.msg_buffer);
                        _toffset += _clength;
                    }
                }
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                //Debug.WriteLine(ex.ToString());
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
            Thread _parsing = new Thread(Parser)
            {
                IsBackground = true
            };
            _parsing.Start();
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
    }
}