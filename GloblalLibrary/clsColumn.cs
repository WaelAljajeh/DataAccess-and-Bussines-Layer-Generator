using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloblalLibrary
{
    public class clsColumn
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsNullable { get; set; }
        public int OrdinalPosition { get; set; }
        public string CSharpType {  get; set; }

        public clsColumn(string name, string dataType, bool isPrimaryKey = false, bool isNullable = true, int ordinalPosition = 0, string cSharpType = null)
        {
            Name = name;
            DataType = dataType;
            IsPrimaryKey = isPrimaryKey;
            IsNullable = isNullable;
            OrdinalPosition = ordinalPosition;
            CSharpType = cSharpType;
        }
    }
}
