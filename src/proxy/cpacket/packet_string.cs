using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Security;

namespace Sniffer.Proxy.CPacket
{
    public class CPACKET_STRING
    {
        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public CPACKET_STRING()
        {
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public static char[] m_delimeter = new char[] { '\r', '\n' };

        private static EventLog m_eventLog = null;
        public static EventLog g_eventLog
        {
            get
            {
                if (m_eventLog == null)
                {
                    string _eventSrc = "Monitoring Service Event Source V45";
                    m_eventLog = new EventLog();

                    if (!EventLog.SourceExists(_eventSrc))
                        EventLog.CreateEventSource(_eventSrc, "Application");

                    m_eventLog.Source = _eventSrc;
                }

                return m_eventLog;
            }
        }

        private static Cryption m_rencrypt = null;
        public static Cryption g_rencrypt
        {
            get
            {
                if (m_rencrypt == null)
                    m_rencrypt = new Cryption("V0607121");

                return m_rencrypt;
            }
        }

        public static string PlainToChiper(string p_plain)
        {
            return g_rencrypt.PlainToChiper(p_plain);
        }

        public static string ChiperToPlain(string p_chiper)
        {
            return g_rencrypt.ChiperToPlain(p_chiper);
        }

        private static string m_connString = null;
        public static string g_connString
        {
            get
            {
                if (String.IsNullOrEmpty(m_connString) == true)
                {
                    m_connString = (string)RegHelper.SNG.GetServer("corptool", "Sniffer", "ConnectionString", String.Empty);

                    string _connString = g_rencrypt.ChiperToPlain(m_connString);
                    if (String.IsNullOrEmpty(_connString) == false)
                        m_connString = _connString;
                }

                return m_connString;
            }
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
        public static string[] GetSplitLines(byte[] p_buffer, char[] p_delimeter)
        {
            return GetSplitLines(p_buffer, p_delimeter, Int32.MaxValue);
        }

        public static string[] GetSplitLines(byte[] p_buffer, char[] p_delimeter, int p_noline)
        {
            byte[] _buffer = new byte[p_buffer.Length];
            int _length = 0;

            for (int i = 0; i < p_buffer.Length; i++)
            {
                _buffer[_length++] = p_buffer[i];

                if (p_buffer[i] == p_delimeter[0])
                {
                    if (--p_noline < 1)
                    {
                        _length--;
                        break;
                    }

                    for (int j = 1; j < p_delimeter.Length; j++)
                    {
                        if (++i >= p_buffer.Length || p_buffer[i] != p_delimeter[j])
                        {
                            i--;
                            break;
                        }
                    }
                }
            }

            Array.Resize<byte>(ref _buffer, _length);
            return Encoding.Default.GetString(_buffer).Split(p_delimeter[0]);
        }

        public static string GetFirstLine(byte[] p_buffer, char[] p_delimeter)
        {
            var _result = String.Empty;

            int _length = -1;
            for (int i = 0; i < p_buffer.Length; i++)
            {
                if (p_buffer[i] == p_delimeter[0])
                {
                    _length = i;
                    break;
                }
            }

            if (_length >= 0)
            {
                byte[] _buffer = new byte[_length];
                Array.Copy(p_buffer, _buffer, _length);

                _result = Encoding.Default.GetString(_buffer);
            }

            return _result;
        }

        public static byte[] GetSelectedLine(byte[] p_buffer, char[] p_delimeter, int p_lineno)
        {
            byte[] _buffer = new byte[p_buffer.Length];
            int _length = 0;

            for (int i = 0; i < p_buffer.Length; i++)
            {
                _buffer[_length++] = p_buffer[i];

                if (p_buffer[i] == p_delimeter[0])
                {
                    if (--p_lineno < 1)
                    {
                        Array.Copy(p_buffer, i, _buffer, --_length, p_buffer.Length - i);
                        _length += p_buffer.Length - i;
                        break;
                    }

                    for (int j = 1; j < p_delimeter.Length; j++)
                    {
                        if (++i < p_buffer.Length && p_buffer[i] != p_delimeter[j])
                        {
                            i--;
                            break;
                        }
                    }

                    _length = 0;
                }
            }

            Array.Resize<byte>(ref _buffer, _length);
            return _buffer;
        }

        private static string PadZeros(int inInt)
        {
            StringBuilder TextField = new StringBuilder();

            string hex = Convert.ToString(inInt, 16);

            if (hex.Length < 8)
            {
                int ix = 8 - hex.Length;
                for (int i = 0; i < ix; ++i)
                {
                    TextField.Append("0");
                }
            }
            TextField.Append(hex);
            return TextField.ToString().ToUpper();
        }

        private static string ConvertByteToHexString(byte inByte)
        {
            StringBuilder TextField = new StringBuilder();

            string hex = Convert.ToString(inByte, 16);

            if (hex.Length == 1)
                TextField.Append("0");

            TextField.Append(hex);

            return TextField.ToString().ToLower();
        }

        public static string GetHexString(byte[] mData)
        {
            StringBuilder HexField = new StringBuilder();
            StringBuilder TextField = new StringBuilder();
            string HeaderStr = "";
            string HeaderStr2 = "";
            byte[] Data;
            int i = 0;

            int newrow = 0;
            int global = 0;
            string hex = " ";
            string numb = " ";
            string Tmp = "";
            int LastRow = mData.GetLength(0) / 16;
            int RemainingBytes = (LastRow * 16) - mData.GetLength(0);

            if (RemainingBytes < 0)
            {
                LastRow++;
                RemainingBytes += 16;
            }

            Data = new byte[LastRow * 16];
            for (i = 0; i < mData.Length; ++i)
            {
                Data[i] = mData[i];
            }

            HeaderStr = " Offset   ";
            HeaderStr2 = " ---------";
            for (i = 0; i < 16; i++)
            {
                HeaderStr += " " + i.ToString("d02");
                HeaderStr2 += "---";
            }

            HexField.Append(HeaderStr + "                  \n");
            HexField.Append(HeaderStr2 + "-------------------\n");

            for (i = 0; i < Data.Length; ++i)
            {
                if (newrow == 0)
                {
                    numb = PadZeros(global);
                    HexField.Append(" " + numb + " ");
                    global += 16;
                }

                hex = ConvertByteToHexString(Data[i]);

                HexField.Append(" " + hex);	// 3 characters

                int g = Data[i];
                if (g > 31 && g < 127)
                {
                    TextField.Append((char)Data[i]);
                }
                else
                {
                    TextField.Append(".");
                }

                ++newrow;

                if (newrow >= 16)
                {
                    HexField.Append("   " + TextField.ToString() + "\n");
                    TextField = new StringBuilder();
                    newrow = 0;
                }
            }

            HexField.Append("\n\n");
            Tmp = HexField.ToString();

            return Tmp;
        }

        //----------------------------------------------------------------------------------------------------//
        //
        //----------------------------------------------------------------------------------------------------//
    }
}