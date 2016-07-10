using System;
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using Sniffer.Proxy.CPacket;
using Sniffer.Proxy.Msn;
using Sniffer.Proxy.Mail;
using OdinSoft.LIB.Configuration;

namespace Sniffer.Server
{
    public partial class PmsService : ServiceBase
    {
        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public PmsService()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        private CPACKET_PARSE m_rawSock = null;
        private CPACKET_PARSE g_rawSock
        {
            get
            {
                if (m_rawSock == null)
                    m_rawSock = new CPACKET_PARSE();
                return m_rawSock;
            }
            set
            {
                m_rawSock = value;
            }
        }

        private MSN m_msnMsgr = null;
        private MSN g_msnMsgr
        {
            get
            {
                if (m_msnMsgr == null)
                    m_msnMsgr = new MSN();
                return m_msnMsgr;
            }
        }

        private SmtpMail m_smtpMail = null;
        private SmtpMail g_smtpMail
        {
            get
            {
                if (m_smtpMail == null)
                    m_smtpMail = new SmtpMail();
                return m_smtpMail;
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        delegate void AddItemCallback(Object sender, PacketArrivedArgs e);

        private void RawSock_PacketArrival(object sender, PacketArrivedArgs args)
        {
            if (args.msg_len > 0)
            {
                if (args.m_internet.type == TYPE_INTERNET.TCP)
                {
                    if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.MSNMSGR || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                    {
                        g_msnMsgr.g_syncQueue.Enqueue(args);
                    }
                    else if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.SMTP || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.SMTP)
                    {
                        g_smtpMail.g_syncQueue.Enqueue(args);
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        protected override void OnStart(string[] args)
        {
            try
            {
                if (g_rawSock.KeepRunning == false)
                {
                    string _ipadrs = (args.Length > 0) ? args[0] : String.Empty;
                    if (String.IsNullOrEmpty(_ipadrs) == true)
                    {
                        _ipadrs = (string)RegHelper.SNG.GetServer("corptool", "Sniffer", "IPAddress", String.Empty);
                        if (String.IsNullOrEmpty(_ipadrs) == true)
                        {
                            IPHostEntry _hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                            if (_hostEntry.AddressList.Length > 0)
                            {
                                foreach (IPAddress ip in _hostEntry.AddressList)
                                    _ipadrs = ip.ToString();
                            }
                        }
                    }

                    g_msnMsgr.Start();
                    g_smtpMail.Start();

                    g_rawSock.Open(_ipadrs);
                    g_rawSock.PacketArrival += new CPACKET_PARSE.PacketArrivedEventHandler(RawSock_PacketArrival);
                    g_rawSock.KeepRunning = true;
                    g_rawSock.Start();

                    CPACKET_STRING.g_eventLog.WriteEntry(String.Format("Start Packet Monitoring Service V45: [{0}]", _ipadrs));
                }
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
        }

        protected override void OnStop()
        {
            g_rawSock.Stop();
            g_rawSock = null;

            CPACKET_STRING.g_eventLog.WriteEntry("Stop Packet Monitoring Service V45");
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
    }
}