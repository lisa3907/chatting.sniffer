using System.Net;
using System.Runtime.InteropServices;

namespace Sniffer.Proxy.CPacket
{
    [StructLayout(LayoutKind.Explicit)]
    public struct OPACKET_INTERNET
    {
        [FieldOffset(0)]
        public byte ip_verlen;          //IP version and IP Header length Combined
        [FieldOffset(1)]
        public byte ip_tos;             //Type of Service
        [FieldOffset(2)]
        public ushort ip_totallength;   //Total Packet Length
        [FieldOffset(4)]
        public ushort ip_id;            //Unique ID
        [FieldOffset(6)]
        public ushort ip_offset;        //Flags and Offset
        [FieldOffset(8)]
        public byte ip_ttl;             //Time To Live
        [FieldOffset(9)]
        public byte ip_protocol;        //type (TCP, UDP, ICMP, Etc.)
        [FieldOffset(10)]
        public ushort ip_checksum;      //IP Header checksum
        [FieldOffset(12)]
        public uint ip_srcaddr;         //Source IP Address
        [FieldOffset(16)]
        public uint ip_destaddr;        //Destination IP Address
    }

    public enum TYPE_INTERNET
    {
        IP = 0,               // dummy for IP
        ICMP = 1,               // control message protocol
        IGMP = 2,               // internet group management protocol
        GGP = 3,               // gateway^2 (deprecated)
        TCP = 6,               // tcp
        PUP = 12,              // pup
        UDP = 17,              // user datagram protocol
        IDP = 22,              // xns idp
        IPV6 = 41,              // IPv6
        ND = 77,              // UNOFFICIAL net disk proto
        ICLFXBM = 78,
        EIGRP = 88,              // EIGRP

        RAW = 255,             // raw IP packet
        MAX = 256,

        UNKNOWN = -1
    }

    public struct SPACKET_INTERNET
    {
        public bool validation;

        public TYPE_INTERNET type;
        public uint version;

        public string src_adrs;
        public ushort src_port;

        public string dst_adrs;
        public ushort dst_port;

        public uint packet_len;
        public uint header_len;
        public uint option_len;
        public uint msg_len;
    }

    public class CPACKET_INTERNET
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public CPACKET_INTERNET()
        {
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        unsafe public static SPACKET_INTERNET Parse(byte[] p_buffer, ref int p_index)
        {
            SPACKET_INTERNET _result = new SPACKET_INTERNET();

            if (p_buffer.Length < p_index + sizeof(OPACKET_INTERNET))
            {
                _result.validation = false;
                p_index = p_buffer.Length;
            }
            else
            {
                _result.validation = true;
                _result.packet_len = (uint)p_buffer.Length;

                fixed (byte* _fxbuffer = &p_buffer[p_index])
                {
                    OPACKET_INTERNET* _ipheader = (OPACKET_INTERNET*)_fxbuffer;

                    _result.header_len = (uint)(_ipheader->ip_verlen & 0x0F) << 2;
                    if (_result.header_len > sizeof(OPACKET_INTERNET))
                        _result.option_len = _result.header_len - (uint)sizeof(OPACKET_INTERNET);

                    _result.version = (uint)(_ipheader->ip_verlen & 0xF0) >> 4;

                    switch (_ipheader->ip_protocol)
                    {
                        case 1:
                            _result.type = TYPE_INTERNET.ICMP;
                            break;
                        case 2:
                            _result.type = TYPE_INTERNET.IGMP;
                            break;
                        case 6:
                            _result.type = TYPE_INTERNET.TCP;
                            break;
                        case 17:
                            _result.type = TYPE_INTERNET.UDP;
                            break;
                        default:
                            _result.type = TYPE_INTERNET.UNKNOWN;
                            break;
                    }

                    IPAddress _srcadrs = new IPAddress(_ipheader->ip_srcaddr);
                    _result.src_adrs = _srcadrs.ToString();
                    short _srcport = *(short*)&_fxbuffer[_result.header_len + 0];
                    _result.src_port = (ushort)IPAddress.NetworkToHostOrder(_srcport);

                    IPAddress _dstadrs = new IPAddress(_ipheader->ip_destaddr);
                    _result.dst_adrs = _dstadrs.ToString();
                    short _dstport = *(short*)&_fxbuffer[_result.header_len + 2];
                    _result.dst_port = (ushort)IPAddress.NetworkToHostOrder(_dstport);

                    _result.msg_len = _result.packet_len - _result.header_len;
                }

                p_index += sizeof(OPACKET_INTERNET);
            }

            return _result;
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
    }
}