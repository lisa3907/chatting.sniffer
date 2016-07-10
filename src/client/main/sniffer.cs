using System;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;
using Sniffer.Proxy.CPacket;
using Sniffer.Proxy.Mail;
using Sniffer.Proxy.Msn;

namespace Sniffer.Client.Main
{
    public partial class sniffer : DevExpress.XtraEditors.XtraForm
    {
        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public sniffer()
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
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            IPHostEntry _hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            if (_hostEntry.AddressList.Length > 0)
            {
                foreach (IPAddress ip in _hostEntry.AddressList)
                    cbIpAdrs.Items.Add(ip.ToString());
            }

            cbIpAdrs.SelectedIndex = 0;

            btStart.Enabled = true;
            btStop.Enabled = false;
        }

        private void btStart_Click(object sender, System.EventArgs e)
        {
            if (g_rawSock.KeepRunning == false && String.IsNullOrEmpty(cbIpAdrs.Text) == false)
            {
                g_smtpMail.Start();
                g_msnMsgr.Start();

                g_rawSock.Open(cbIpAdrs.Text);
                g_rawSock.PacketArrival += new CPACKET_PARSE.PacketArrivedEventHandler(RawSock_PacketArrival);
                g_rawSock.KeepRunning = true;
                g_rawSock.Start();

                btStart.Enabled = false;
                btStop.Enabled = true;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            lvMessages.Items.Clear();
            rtMessage.Text = "";
        }

        private void lvMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMessages.SelectedItems.Count > 0)
            {
                rtMessage.Text = CPACKET_STRING.GetHexString((byte[])lvMessages.SelectedItems[0].SubItems[5].Tag);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g_rawSock.Stop();
            g_rawSock = null;

            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog _fdialog = new SaveFileDialog()
            {
                CreatePrompt = true,
                OverwritePrompt = true,
                FileName = "packets.txt",
                DefaultExt = "txt",
                Filter = "Text files (*.txt)|*.txt",
                InitialDirectory = Application.StartupPath
            };

            if (_fdialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter _writer = new StreamWriter(_fdialog.FileName))
                {
                    foreach (ListViewItem _lv in lvMessages.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem _sv in _lv.SubItems)
                        {
                            _writer.Write(_sv.Text);
                            _writer.Write("\t");
                        }
                        _writer.WriteLine();
                    }
                }
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            g_rawSock.Stop();
            g_rawSock = null;

            btStart.Enabled = true;
            btStop.Enabled = false;
        }

        private void sniffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            g_rawSock.Stop();
            g_rawSock = null;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        delegate void AddItemCallback(Object sender, PacketArrivedArgs e);

        private void RawSock_PacketArrival(object sender, PacketArrivedArgs args)
        {
            if (this.lvMessages.InvokeRequired)
            {
                AddItemCallback d = new AddItemCallback(RawSock_PacketArrival);
                this.Invoke(d, new object[] { sender, args });
            }
            else if (args.msg_len > 0)
            {
                var _viewmsg = false;
                var _message = String.Empty;

                if (args.m_internet.type == TYPE_INTERNET.TCP)
                {
                    _viewmsg = true;

                    _message = CPACKET_STRING.GetFirstLine(args.msg_buffer, CPACKET_STRING.m_delimeter);
                    if (String.IsNullOrEmpty(_message) == false)
                    {
                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.MSNMSGR || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.MSNMSGR)
                        //{
                        //    g_msnMsgr.g_syncQueue.Enqueue(args);

                        //    string[] _cmds = _message.Split(' ');
                        //    if (_cmds[0] != "PNG" && _cmds[0] != "QNG")
                        //    {
                        //        _message = HttpUtility.UrlDecode(_message);
                        //        _viewmsg = true;
                        //    }
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.NATEON || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.NATEON)
                        //{
                        //    string[] _cmds = _message.Split(' ');
                        //    if (_cmds[0] != "PING" && _cmds[0] != "QNG")
                        //        _viewmsg = true;
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.IMAP || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.IMAP)
                        //{
                        //    _viewmsg = true;
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.IMAPS || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.IMAPS)
                        //{
                        //    _viewmsg = true;
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.SMTP || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.SMTP)
                        //{
                        //    g_smtpMail.g_syncQueue.Enqueue(args);
                        //    _viewmsg = true;
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.POP || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.POP)
                        //{
                        //    _viewmsg = true;
                        //}

                        //if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.POP3 || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.POP3)
                        //{
                        //    _viewmsg = true;
                        //}

                        //else if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.LOGIN || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.LOGIN)
                        //{
                        //    _viewmsg = true;
                        //}
                        //else if (args.m_internet.dst_port == (ushort)TYPE_TCP_PORT.PASSWD_SERVER || args.m_internet.src_port == (ushort)TYPE_TCP_PORT.PASSWD_SERVER)
                        //{
                        //    _viewmsg = true;
                        //}

                    }
                }

                if (_viewmsg == true)
                {
                    ListViewItem _lvItem = lvMessages.Items.Add(args.m_internet.type.ToString());
                    {
                        _lvItem.SubItems.Add(args.m_internet.src_adrs);
                        _lvItem.SubItems.Add(args.m_internet.src_port.ToString());
                        _lvItem.SubItems.Add(args.m_internet.dst_adrs);
                        _lvItem.SubItems.Add(args.m_internet.dst_port.ToString());
                        _lvItem.SubItems.Add(_message).Tag = args.msg_buffer;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
    }
}