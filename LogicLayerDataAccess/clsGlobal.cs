using DataAccessLayerForCodeGenerator;
using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsGlobal
    {
       static string _GetTheUsingHeader()
       {
            return $@"
       using System;
       using System.Collections.Generic;
       using System.Linq; 
       using System.Text;
       using System.Data.SqlClient;
       using System.Threading.Tasks;";
       }
       static string _GetTheNameSpaceHeader(string dbName)
       {
          return $@"namespace DataAccess_ {dbName}"+
                " @{"
          
         ;
       }
       static string _GetTheDataSettingClass(string ConnectionString)
       {
            
                return @"
            public class clsDataAccessSettings{
            public static string ConnectionString=" + "\"" + ConnectionString + "\"" + ";\n" +
                "}" +
                "}";
            
        }
        static string _GetTheMainClass(string TableName)
        {
            return $@"public class cls{TableName}
             " + @"
              {
              ";
        }
        public static string GetTheDataSettingInfo(string DBName)
        {
            return _GetTheUsingHeader() + _GetTheNameSpaceHeader(DBName)+_GetTheDataSettingClass(clsDataAccessSettings.ConnectionString);
        }
        public static string GetTheClassInfo(string DBName,string TableName)
        {
            return _GetTheUsingHeader() + _GetTheNameSpaceHeader(DBName)+_GetTheMainClass(TableName);
        }
        public static string GetObjectConverted(List<clsColumn> ColList)
        {
            return string.Join(Environment.NewLine, ColList.Where(c => !c.IsGetByEnabled)
            .Select(c => $"{("{Value}= " + clsUtil.ConvertObjectToDataType(c)).Replace("{Value}", c.Name)};"));
        }

        public static string GetCommandValues(List<clsColumn> ColList, bool GetEnable)
        {
            if (!GetEnable)
                return string.Join(Environment.NewLine, ColList
                   .Select(c => $"command.Parameters.AddWithValue(\"{c.Name}\",{c.Name});"));
            else
                return string.Join(Environment.NewLine, ColList.Where(c => c.IsGetByEnabled)
               .Select(c => $"command.Parameters.AddWithValue(\"{c.Name}\",{c.Name});"));
        }
       public static string GetTheSetClauseInUpdateOperation(List<clsColumn> ColList)
        {
            return string.Join(", ", ColList.Where(c => !c.IsPrimaryKey)
               .Select(c => $"{c.Name} = @{c.Name}"));
        }

       public static string GetParameterList(List<clsColumn> ColList, bool IsWithDataType = false, bool IsColValue = false, string prefix = "")
        {
            List<string> parameters = new List<string>();

            foreach (clsColumn col in ColList)
            {
                if (IsWithDataType)
                    parameters.Add($"{prefix} {col.CSharpType} {col.Name}");
                else
                {
                    if (IsColValue)
                    {
                        parameters.Add($"@{col.Name}");
                    }
                    else
                        parameters.Add(col.Name);
                }

            }

            return string.Join(", ", parameters);
        }
       public static void SetCommonCrudTemplateValues(StringBuilder FileContent, clsTableLogic Table, clsColumn PrimaryKey, string prefix = "")
        {
            StringBuilder Parmeters = new StringBuilder();
            Parmeters.Append(GetParameterList(Table.ColumnsList, true, false, prefix));
            FileContent.Replace("{TableName}", Table.TableName);
            FileContent.Replace("{ParameteList}", Parmeters.ToString());
            FileContent.Replace("{Commands}", GetCommandValues(Table.ColumnsList, false));
            if (PrimaryKey != null)
                FileContent.Replace("{PrimaryKeyID}", PrimaryKey?.Name ?? "");
        }
    }
}
