using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3SharperObjects
{
    public class TableDefinition
    {
        public int amount { get; set; }
        public IList<DefinitionStructure> defStructList { get; set; }

        public TableDefinition()
        {
            amount = 0;
            defStructList = new List<DefinitionStructure>();
        }

        public void load(BinaryReader reader)
        {
            amount = reader.ReadInt32();
            for (int i = 0; i < amount; i++)
            {
                DefinitionStructure defStruct = new DefinitionStructure();
                defStruct.load(reader);
                defStructList.Add(defStruct);
            }
        }

        public string ToString()
        {
            string info = "table[" + defStructList.Count + "]";
            return info;
        }
    }
}
