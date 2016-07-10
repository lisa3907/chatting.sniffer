using System;
using System.Runtime.InteropServices;

namespace Sniffer.Proxy.CPacket
{
    [StructLayout(LayoutKind.Explicit)]
    public struct OPACKET_ETHERNET
    {
        [FieldOffset(0)]
        public byte[] ether_source;
        [FieldOffset(5)]
        public byte[] ether_destination;
        [FieldOffset(10)]
        public ushort ether_type;
    }

    public enum ENUM_ETHERTYPE
    {
        ETHERTYPE_PUP = 0x0200,	// PUP protocol
        ETHERTYPE_SPRITE = 0x0500,
        ETHERTYPE_NS = 0x0600,
        ETHERTYPE_TRAIL = 0x1000,
        ETHERTYPE_MOPDL = 0x6001,
        ETHERTYPE_MOPRC = 0x6002,
        ETHERTYPE_DN = 0x6003,
        ETHERTYPE_LAT = 0x6004,
        ETHERTYPE_SCA = 0x6007,
        ETHERTYPE_IP = 0x0800,	// IP protocol
        ETHERTYPE_ARP = 0x0806,	// Addr. resolution protocol
        ETHERTYPE_REVARP = 0x8035,	// reverse Addr. resolution protocol
        ETHERTYPE_LANBRIDGE = 0x8038,
        ETHERTYPE_DECDNS = 0x803c,
        ETHERTYPE_DECDTS = 0x803e,
        ETHERTYPE_VEXP = 0x805b,
        ETHERTYPE_VPROD = 0x805c,
        ETHERTYPE_ATALK = 0x809b,
        ETHERTYPE_AARP = 0x80f3,
        ETHERTYPE_8021Q = 0x8100,
        ETHERTYPE_IPX = 0x8137,
        ETHERTYPE_IPV6 = 0x86dd,
        ETHERTYPE_LOOPBACK = 0x9000
    }

    public struct SPACKET_ETHERNET
    {
        public string src_mac;
        public string dst_mac;

        public ENUM_ETHERTYPE type;

        public bool validation;

        public uint msg_len;
        //public byte[] msg_buffer = null;
    }

    public class CPACKET_ETHERNET
    {
        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public CPACKET_ETHERNET()
        {
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
        public static SPACKET_ETHERNET Parse(byte[] p_buffer, ref int p_index)
        {
            SPACKET_ETHERNET _result = new SPACKET_ETHERNET()
            { /*if (p_buffer.Length < sizeof(OPACKET_ETHERNET))*/ /*{*/ /*    _result.validation = false;*/ /*}*/ /*else*/ /*{*/
                validation = true,
                src_mac = String.Empty,
                dst_mac = String.Empty,
                type = ENUM_ETHERTYPE.ETHERTYPE_IP,
                msg_len = (uint)p_buffer.Length
            };
            //_result.msg_buffer = new byte[_result.msg_len];
            //Array.Copy(p_buffer, 0, _result.msg_buffer, 0, (int)_result.msg_len);
            //}

            return _result;
        }

        //------------------------------------------------------------------------------------------------------//
        //
        //------------------------------------------------------------------------------------------------------//
   }
}