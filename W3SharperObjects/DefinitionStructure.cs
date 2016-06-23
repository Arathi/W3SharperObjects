using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3SharperObjects
{
    public class DefinitionStructure
    {
        public Identity originID { get; set; }
        public Identity newID { get; set; }
        public int amount { get; set; }
        public IList<ModificationStructure> modifcations { get; set; }

        public DefinitionStructure()
        {
            originID = null;
            newID = null;
            amount = 0;
            modifcations = new List<ModificationStructure>();
        }

        public void load(BinaryReader reader)
        {
            originID = new Identity(reader.ReadBytes(4));
            newID = new Identity(reader.ReadBytes(4));
            amount = reader.ReadInt32();
            for (int i = 0; i < amount; i++)
            {
                ModificationStructure modifcation = new ModificationStructure();
                modifcation.load(reader);
                modifcations.Add(modifcation);
            }
        }

        public override string ToString()
        {
            string info = "";
            if (newID.Numeric == 0)
            {
                info = originID.Str + ":" + originID.Str;
            }
            else
            {
                info = newID.Str + ":" + originID.Str;
            }
            info += "(" + modifcations.Count + "项改动)";
            return info;
        }
    }
}
