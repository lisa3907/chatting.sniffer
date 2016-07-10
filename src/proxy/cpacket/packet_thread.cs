using System;
using System.Diagnostics;
using System.Threading;

namespace Sniffer.Proxy.CPacket
{
    public class CPACKET_THREAD
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        private Thread m_threading = null;
        private string m_ipadrs = null;

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public delegate void PacketArrivedEventHandler(Object sender, PacketArrivedArgs args);
        public event PacketArrivedEventHandler PacketArrival;

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public CPACKET_THREAD()
        {
        }

        ~CPACKET_THREAD()
        {
            Stop();
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

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public void Open(string p_ipadrs)
        {
            m_ipadrs = p_ipadrs;
        }
        
        public bool Start()
        {
            var _result = false;

            if (m_threading == null)
            {
                m_threading = new Thread(new ThreadStart(SniffingProc));
                m_threading.IsBackground = true;
                m_threading.Start();

                _result = true;
            }

            return _result;
        }

        public void Stop()
        {
            if (m_threading != null)
            {
                m_threading.Abort();
                m_threading.Join();
                m_threading = null;
            }
        }

        private void SniffingProc()
        {
            try
            {
                using (CPACKET_WORKER _worker = new CPACKET_WORKER(m_ipadrs))
                {
                    _worker.PacketArrival += new CPACKET_WORKER.PacketArrivedEventHandler(Worker_PacketArrival);
                    _worker.Run();
                }
            }
            catch (ThreadAbortException ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                return;
            }
            catch (Exception ex)
            {
                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
        }

        void Worker_PacketArrival(object sender, PacketArrivedArgs args)
        {
            if (PacketArrival != null)
                PacketArrival(this, args);
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
    }
}