using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3SharperObjects
{
    public class W3UFile
    {
        public int version { get; set; } // 1
        public TableDefinition originTable { get; set; }
        public TableDefinition customTable { get; set; }

        public W3UFile()
        {
            init();
        }

        public W3UFile(string path)
        {
            init();
            load(path);
        }

        public void init()
        {
            version = 1;
            originTable = new TableDefinition();
            customTable = new TableDefinition();
        }

        public void load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            version = reader.ReadInt32();
            originTable.load(reader);
            customTable.load(reader);
        }

        public string ToString()
        {
            string info = String.Format("w3u({0},{1})", originTable.amount, customTable.amount);
            return info;
        }
    }
}
