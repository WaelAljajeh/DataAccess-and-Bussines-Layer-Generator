using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloblalLibrary
{
    public class clsUtil
    {
        public static string ConvertObjectToDataType(clsColumn col)
        {
            if (col == null) return null;

            string conversion;

            switch (col.CSharpType.Replace("?", "")) // Remove nullable indicator for conversion
            {
                case "int":
                    conversion = "Convert.ToInt32({Value})";
                    break;
                case "long":
                    conversion = "Convert.ToInt64({Value})";
                    break;
                case "short":
                    conversion = "Convert.ToInt16({Value})";
                    break;
                case "byte":
                    conversion = "Convert.ToByte({Value})";
                    break;
                case "bool":
                    conversion = "Convert.ToBoolean({Value})";
                    break;
                case "decimal":
                    conversion = "Convert.ToDecimal({Value})";
                    break;
                case "double":
                    conversion = "Convert.ToDouble({Value})";
                    break;
                case "float":
                    conversion = "Convert.ToSingle({Value})";
                    break;
                case "string":
                    conversion = "Convert.ToString({Value})";
                    break;
                case "DateTime":
                    conversion = "Convert.ToDateTime({Value})";
                    break;
                case "Guid":
                    conversion = "Guid.Parse({Value}.ToString())";
                    break;
                case "byte[]":
                    conversion = "({Value} as byte[])";
                    break;
                default:
                    conversion = $"({col.CSharpType.Replace("?", "")}){{Value}}"; // fallback cast
                    break;
            }

            if (col.IsNullable)
                return "{Value} == DBNull.Value ? null : " + conversion;

            return conversion;
        }
        public static string GetDefaultValue(string cSharpType)
        {
            switch (cSharpType)
            {
                case "int":
                    return "-1";
                case "string":
                    return "\"\"";
                case "DateTime":
                    return "DateTime.MinValue";
                case "byte":
                    return "0";
                case "double":
                    return "0.0";
                case "bool":
                    return "false";
                case "decimal":
                    return "0.0m";
                default:
                    return "default";
            }
        }
    }
}
