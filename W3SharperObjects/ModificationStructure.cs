using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3SharperObjects
{
    public class ModificationStructure
    {
        public const int VARIABLE_TYPE_INT = 0; // int
        public const int VARIABLE_TYPE_REAL = 1; // float
        public const int VARIABLE_TYPE_UNREAL = 2; // float, [0,1]
        public const int VARIABLE_TYPE_STRING = 3; // string (End with null)
        // public const int VARIABLE_TYPE_BOOL = 4;
        // public const int VARIABLE_TYPE_CHAR = 5;
        // ... 最多到21号

        public Identity modifcationID { get; set; }
        public int variableType { get; set; }
        public object value { get; set; }
        public int end { get; set; }

        public ModificationStructure()
        {
            modifcationID = null;
            variableType = 0;
            value = null;
            end = 0;
        }

        public void load(BinaryReader reader)
        {
            modifcationID = new Identity(reader.ReadBytes(4));
            variableType = reader.ReadInt32();
            // 根据变量类型获取值
            int vInt = 0;
            float vReal = 0f;
            string vString = null;
            IList<byte> vBytes = null;
            switch (variableType)
            {
                case VARIABLE_TYPE_INT:
                    vInt = reader.ReadInt32();
                    value = vInt;
                    break;
                case VARIABLE_TYPE_REAL:
                case VARIABLE_TYPE_UNREAL:
                    vReal = reader.ReadSingle();
                    value = vReal;
                    break;
                case VARIABLE_TYPE_STRING:
                    vBytes = new List<byte>();
                    while (true)
                    {
                        byte b = reader.ReadByte();
                        if (b == 0x00)
                        {
                            break;
                        }
                        vBytes.Add(b);
                    }
                    // byte数组转字符串
                    vString = System.Text.Encoding.UTF8.GetString(vBytes.ToArray());
                    value = vString;
                    break;
                default:
                    // 其他类型暂时当作INT
                    vInt = reader.ReadInt32();
                    value = vInt;
                    break;
            }
            end = reader.ReadInt32();
        }

        public override string ToString()
        {
            return modifcationID + ": " + value;
        }
    }
}
