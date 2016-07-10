using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Sniffer.Proxy.CPacket
{
    public class PacketArrivedArgs : EventArgs
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public PacketArrivedArgs()
        {
        }

        public SPACKET_ETHERNET m_ethernet;
        public SPACKET_INTERNET m_internet;
        public SPACKET_TCP m_tcp;

        public string m_command;

        public uint msg_len;
        public byte[] msg_buffer;
    }

    public class CPACKET_PARSE : IDisposable
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        private const int c_LengthOfRcvBuffer = 65536;

        private byte[] m_rcvBuffer = null;
        private Socket m_socket = null;

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public CPACKET_PARSE()
        {
            ErrorOccurred = false;
            m_rcvBuffer = new byte[c_LengthOfRcvBuffer];
        }

        ~CPACKET_PARSE()
        {
            Dispose();
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        private void Parse(byte[] p_buffer, int p_length)
        {
            PacketArrivedArgs e = new PacketArrivedArgs();

            int p_index = 0;
            byte[] _buffer = new byte[p_length];
            Array.Copy(p_buffer, 0, _buffer, 0, p_length);

            e.m_ethernet = CPACKET_ETHERNET.Parse(_buffer, ref p_index);
            if (e.m_ethernet.validation == false)
                return;

            e.m_internet = CPACKET_INTERNET.Parse(_buffer, ref p_index);
            if (e.m_internet.validation == false)
                return;

            e.m_tcp = CPACKET_TCP.Parse(_buffer, ref p_index);
            if (e.m_tcp.validation == false)
                return;

            if (p_length > p_index)
            {
                e.msg_len = (uint)(p_length - p_index);
                e.msg_buffer = new byte[e.msg_len];
                Array.Copy(_buffer, p_index, e.msg_buffer, 0, (int)e.msg_len);
            }

            OnPacketArrival(e);
        }

        private void Receive(IAsyncResult ar)
        {
            if (m_socket != null)
            {
                int _received = m_socket.EndReceive(ar);
                Parse(m_rcvBuffer, _received);

                if (KeepRunning == true && ErrorOccurred == false)
                    Start();
            }
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        private bool m_errOccurred = false;
        public bool ErrorOccurred
        {
            get
            {
                return m_errOccurred;
            }
            set
            {
                m_errOccurred = value;
            }
        }

        public bool m_keepRunning = false;
        public bool KeepRunning
        {
            get
            {
                return m_keepRunning;
            }
            set
            {
                m_keepRunning = value;
            }
        }
        
        public delegate void PacketArrivedEventHandler(Object sender, PacketArrivedArgs args);
        public event PacketArrivedEventHandler PacketArrival;

        protected virtual void OnPacketArrival(PacketArrivedArgs e)
        {
            if (PacketArrival != null)
                PacketArrival(this, e);
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public void Open(string p_ipadrs)
        {
            if (m_socket == null)
            {
                try
                {
                    m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                    m_socket.Blocking = false;
                    m_socket.Bind(new IPEndPoint(IPAddress.Parse(p_ipadrs), 0));

                    m_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, 1);

                    byte[] _ioc_in = new byte[4] { 1, 0, 0, 0 };
                    byte[] _ioc_out = new byte[4];

                    int _retcode = m_socket.IOControl(IOControlCode.ReceiveAll, _ioc_in, _ioc_out);
                    _retcode = _ioc_out[0] + _ioc_out[1] + _ioc_out[2] + _ioc_out[3];
                    if (_retcode != 0)
                        ErrorOccurred = true;
                }
                catch (SocketException ex)
                {
                    CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                    Debug.WriteLine(ex.ToString());
                    ErrorOccurred = true;
                }
            }
        }
        
        public void Start()
        {
            IAsyncResult ar = m_socket.BeginReceive(
                m_rcvBuffer, 0, c_LengthOfRcvBuffer, SocketFlags.None, new AsyncCallback(Receive), this
                );
        }

        public void Stop()
        {
            if (m_socket != null)
            {
                if (m_socket.Connected == true)
                {
                    m_socket.Shutdown(SocketShutdown.Both);
                    m_socket.Close();
                }

                KeepRunning = false;
            }
        }
    
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
    }
}