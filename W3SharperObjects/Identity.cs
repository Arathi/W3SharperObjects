using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3SharperObjects
{
    public class Identity
    {
        public byte[] data { get; set; }

        private string str;
        private int numeric;
        
        public Identity()
        {
            data = new byte[4];
        }

        public Identity(byte[] bytes)
        {
            data = bytes;
        }

        public string Str
        {
            get
            {
                if (str == null)
                {
                    str = ToString();
                }
                return str;
            }
        }

        public int Numeric
        {
            get
            {
                if (numeric == 0)
                {
                    numeric = ToNumeric();
                }
                return numeric;
            }
        }

        public override string ToString()
        {
            string str = "'";
            if (data != null && data.Length == 4)
            {
                if (data[0] == 0 && data[1] == 0 && data[2] == 0 && data[3] == 0)
                {
                    return null;
                }
                foreach (var b in data)
                {
                    char c = (char) b;
                    str += c;
                }
                str += "'";
            }
            else
            {
                return null;
            }
            return str;
        }

        public int ToNumeric()
        {
            if (data != null && data.Length == 4)
            {
                return (data[0] << 24) | (data[1] << 16) | (data[2] << 8) | data[3];
            }
            return 0;
        }
    }
}
