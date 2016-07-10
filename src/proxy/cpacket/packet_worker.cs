using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sniffer.Proxy.CPacket
{
    public class CPACKET_WORKER : IDisposable
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        private const int DefaultBufferSize = 65536;
        private Socket m_socket = null;

        private byte[] m_recvBuffer = null;
        private int m_recvBuffSize = -1;

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
        public CPACKET_WORKER(string ip)
            : this(ip, DefaultBufferSize)
        {
        }

        public CPACKET_WORKER(string p_ipadrs, int p_recvbuffsize)
        {
            m_recvBuffSize = p_recvbuffsize;
            m_recvBuffer = new byte[m_recvBuffSize];

            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            m_socket.Blocking = false;
            m_socket.Bind(new IPEndPoint(IPAddress.Parse(p_ipadrs), 0));

            m_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, 1);

            byte[] _ioc_in = new byte[4] { 1, 0, 0, 0 };
            byte[] _ioc_out = new byte[4];

            int _retcode = m_socket.IOControl(IOControlCode.ReceiveAll, _ioc_in, _ioc_out);
            _retcode = _ioc_out[0] + _ioc_out[1] + _ioc_out[2] + _ioc_out[3];
            if (_retcode != 0)
            {
                throw new SystemException("Can't assign IOControl options.");
            }
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        ~CPACKET_WORKER()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_socket != null)
            {
                m_socket.Shutdown(SocketShutdown.Both);
                m_socket.Close();
                m_socket = null;
            }

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
            e.m_internet = CPACKET_INTERNET.Parse(_buffer, ref p_index);
            e.m_tcp = CPACKET_TCP.Parse(_buffer, ref p_index);

            if (p_length > p_index)
            {
                e.msg_len = (uint)(p_length - p_index);
                e.msg_buffer = new byte[e.msg_len];
                Array.Copy(_buffer, p_index, e.msg_buffer, 0, (int)e.msg_len);
            }

            OnPacketArrival(e);
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public void Run()
        {
            int receiveSize = 0;
            while (true)
            {
                if (m_socket.Available > 0)
                {
                    receiveSize = m_socket.Receive(m_recvBuffer, m_recvBuffSize, SocketFlags.None);

                    if (receiveSize > 0)
                        Parse(m_recvBuffer, receiveSize);
                }

                Thread.Sleep(10);
            }
        }
    }
}