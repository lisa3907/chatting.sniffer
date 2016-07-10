using System.Runtime.InteropServices;

namespace Sniffer.Proxy.CPacket
{
    [StructLayout(LayoutKind.Explicit)]
    public struct OPACKET_TCP
    {
        [FieldOffset(0)]
        public ushort tcp_srcport;
        [FieldOffset(2)]
        public ushort tcp_dstport;
        [FieldOffset(4)]
        public uint tcp_seqno;
        [FieldOffset(8)]
        public uint tcp_ack;
        [FieldOffset(12)]
        public byte tcp_headerlen;
        [FieldOffset(13)]
        public byte tcp_falgs;
        [FieldOffset(14)]
        public ushort tcp_windowsize;
        [FieldOffset(16)]
        public ushort tcp_checksum;
        [FieldOffset(18)]
        public ushort tcp_options;
    }

    public struct SPACKET_TCP
    {
        public bool validation;

        public ushort src_port;
        public ushort dst_port;

        public uint seqno;
        public uint ack;
        public uint header_len;
        public uint option_len;
        public uint falgs;

        public ushort window_size;
        public ushort checksum;
        public ushort options;

        public uint packet_len;

        public uint msg_len;
        //public byte[] msg_buffer;
    }

    public enum TYPE_TCP_PORT
    {
        MSNMSGR = 1863,
        NATEON = 5004,

        TIMESERVER = 37,
        NAMESERVER = 42,
        DNS = 43,
        MTP = 57,
        RJE = 77,
        FINGER = 79,
        HTTP2 = 8080,
        SSDP = 1031,
        SSDP2 = 1032,
        SQL = 1433,
        TTYLINK = 87,
        SUPDUP = 95,
        EPMEP = 135,
        NBNS = 137,
        NBDTGRM = 138,
        NBSSN = 139,
        EXECSERVER = 512,
        LOGINSERVER = 513,
        CMDSERVER = 514,
        WHOSERVER = 513,
        ROUTESERVER = 520,

        ECHO = 7,// tcp	   udp
        DISCARD = 9, // tcp	   udp
        SYSTAT = 11, // tcp
        DAYTIME = 13, // tcp	   udp
        NETSTAT = 15, // tcp
        QOTD = 17, // tcp	   udp
        CHARGEN = 19, // tcp	   udp
        FTP_DATA = 20, // tcp
        FTP = 21, // tcp
        TELNET = 23, // tcp
        SMTP = 25, // tcp
        TIME = 37, // tcp	   udp
        RLP = 39, // udp
        NAME = 42, // tcp	   udp
        WHOIS = 43, // tcp
        DOMAIN = 53, // tcp	   udp
        BOOTP = 67, // udp
        TFTP = 69, // udp
        HTTP = 80, // tcp
        LINK = 87, // tcp
        HOSTNAMES = 101, //tcp
        ISP_TSAP = 102, //tcp
        DICTIONARY = 103, //tcp
        X400_SND = 104, //tcp
        CSNET_NS = 105, //tcp
        POP = 109, //tcp
        POP3 = 110, //tcp
        PORTMAP = 111, //tcp	   udp
        AUTH = 113, //tcp
        SFTP = 115, //tcp
        PATH = 117, //tcp
        NNTP = 119, //tcp
        NTP = 123, //udp
        NB_NAME = 137, //udp
        NB_DATAGRAM = 138, //udp
        NB_SESSION = 139, //tcp
        IMAP = 143, //tcp
        NEWS = 144, //tcp
        SGMP = 153, //udp
        TCPREPO = 158, //tcp
        SNMP = 161, //udp
        SNMP_TRAP = 162, //udp
        PRINT_SRV = 170, //tcp
        VMNET = 175, //tcp
        LOAD = 315, //udp
        VMNET0 = 400, //tcp
        HTTPS = 443, //tcp
        SYTEK = 500, //udp
        EXEC = 512, //tcp
        BIFF = 512, //udp
        LOGIN = 513, //tcp
        WHO = 513, //udp
        SHEL = 514, //tcp
        SYSLOG = 514, //udp
        PRINTER = 515, //tcp
        TALK = 517, //udp
        NTALK = 518, //udp
        EFS = 520, //tcp
        ROUTE = 520, //udp
        TIMED = 525, //udp
        TEMPO = 526, //tcp
        COURIER = 530, //tcp
        CONFERENCE = 531, //tcp
        RVD_CONTROL = 531, //udp
        NETNEWS = 532, //tcp
        NETWALL = 533, //udp
        UUCP = 540, //tcp
        KLOGIN = 543, //tcp
        KSHEL = 544, //tcp
        NEW_RWHO = 550, //udp
        REMOTEFS = 556, //tcp
        RMONITOR = 560, //udp
        MONITOR = 561, //udp
        GARCON = 600, //tcp
        MAITRD = 601, //tcp
        BUSBOY = 602, //tcp
        ACCTMASTER = 700, //udp
        ACCTSLAVE = 701, //udp
        ACCT = 702, //udp
        ACCTLOGIN = 703, //udp
        ACCTPRINTER = 704, //udp
        ACCTINFO = 705, //udp
        ACCTSLAVE2 = 706, //udp
        ACCTDISK = 707, //udp
        KERBEROS = 750, //tcp	   udp
        KERBEROS_MASTER = 751, //tcp	   udp
        PASSWD_SERVER = 752, //udp
        USERREG_SERVER = 753, //udp
        KRB_PROP = 754, //tcp
        ERRLOGIN = 888, //tcp
        IMAPS = 993, //tcp
        DLSW_UDP = 2067,
        DLSW_TCP = 2065
    }

    public enum SMTP_TYPE
    {
        NULL,
        SMTP,
        ESMTP
    }

    class CPACKET_TCP
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public CPACKET_TCP()
        {
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        unsafe public static SPACKET_TCP Parse(byte[] p_buffer, ref int p_index)
        {
            SPACKET_TCP _result = new SPACKET_TCP();

            if (p_buffer.Length < p_index + sizeof(OPACKET_TCP))
            {
                _result.validation = false;
                p_index = p_buffer.Length;
            }
            else
            {
                _result.validation = true;
                _result.packet_len = (uint)p_buffer.Length;
                _result.option_len = 0;

                fixed (byte* _fxbuffer = &p_buffer[p_index])
                {
                    OPACKET_TCP* _tcpheader = (OPACKET_TCP*)_fxbuffer;

                    _result.src_port = _tcpheader->tcp_srcport;
                    _result.dst_port = _tcpheader->tcp_dstport;

                    _result.seqno = _tcpheader->tcp_seqno;
                    _result.ack = _tcpheader->tcp_ack;

                    _result.header_len = (uint)((_tcpheader->tcp_headerlen >> 4) * 4);
                    if (_result.header_len > sizeof(OPACKET_TCP))
                        _result.option_len = _result.header_len - (uint)sizeof(OPACKET_TCP);

                    _result.falgs = _tcpheader->tcp_falgs;

                    _result.window_size = _tcpheader->tcp_windowsize;
                    _result.checksum = _tcpheader->tcp_checksum;
                    _result.options = _tcpheader->tcp_options;

                    _result.msg_len = _result.packet_len - _result.header_len;
                }

                p_index += sizeof(OPACKET_TCP);
                if (p_buffer.Length >= p_index + (int)_result.option_len)
                    p_index += (int)_result.option_len;
            }

            return _result;
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
    }
}
