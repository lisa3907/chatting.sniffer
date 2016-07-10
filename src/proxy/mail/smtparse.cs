using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sniffer.Proxy.CPacket;

namespace Sniffer.Proxy.Mail
{
    public class smtparse
    {
        Hashtable _headers;
        public smtparse()
        {
            _headers = new Hashtable();
        }

        public smtparse(byte[] p_content)
            : this()
        {
            this.SetHeader(p_content);
        }

        public string this[string headerName]
        {
            get
            {
                string _header = (string) _headers[headerName.ToLower()];
                if (String.IsNullOrEmpty(_header) == true)
                    _header = String.Empty;
                else if (_header.Trim().TrimStart('\"').StartsWith("=?") == true)
                    _header = String.Empty;

                return _header;
            }

            set
            {
                _headers[headerName.ToLower()] = value;
            }
        }

        public void Add(string headerName, string header)
        {
            _headers[headerName.ToLower()] = header;
        }

        public void Remove(string headerName)
        {
            _headers.Remove(headerName.ToLower());
        }
        
        public int Count
        {
            get
            {
                return _headers.Count;
            }
        }
        
        public ICollection Values
        {
            get
            {
                return _headers.Values;
            }
        }

        public void SetHeader(byte[] p_content)
        {
            int _index = 0;

            try
            {
                //unfolding
                while (p_content.Length > _index)
                {
                    //+OK line
                    if (p_content[_index] == 43)
                    {
                        while (true)
                        {
                            if (++_index >= p_content.Length)
                                break;

                            if ((p_content[_index] == 13) && (p_content[_index + 1] == 10))
                            {
                                _index += 2;
                                break;
                            }
                        }
                    }

                    if (_index >= p_content.Length)
                        break;

                    //break
                    if ((p_content[_index] == 13) && (p_content[_index + 1] == 10))
                    {
                        if (++_index >= p_content.Length)
                            break;

                        if (p_content[_index + 1] == 13)
                        {
                            if (++_index >= p_content.Length)
                                break;

                            if (p_content[_index + 1] == 10)
                            {
                                _index += 2;
                                break;
                            }
                        }
                    }

                    _index++;
                }
            }
            catch (Exception ex)
            {
                string _error = String.Format("\r\nSize of message: {0}, last location: {1}", p_content.Length, _index);

                CPACKET_STRING.g_eventLog.WriteEntry(ex.ToString() + _error);
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                string[] _headers = Encoding.Default.GetString(p_content, 0, _index).Split("\r\n".ToCharArray());
                foreach (string _header in _headers)
                {
                    string[] _items = _header.Split(":".ToCharArray());
                    if (_items.Length > 1)
                        this.Add(_items[0].Trim(), _items[1].Trim());
                }
            }
        }
    }
}