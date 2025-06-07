using DataAccessLayerForCodeGenerator;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GloblalLibrary;
using System.Security.Cryptography;

namespace LogicLayerDataAccess
{
    public class clsDataAccessGenerate
    {
       //static bool IsInInserting=false;
      // static bool IsWithDataType = false;
      
       static string GenerateTheHeader(string DataBaseName)
        {
         return $@"
         using System;
         using System.Collections.Generic;
         using System.Linq; 
         using System.Text;
         using System.Data.SqlClient;
         using System.Threading.Tasks;
         namespace DataAccess_{DataBaseName}
         "+"{"
         ;
        }
        static string GenerateTheClassOfSettings(string ConnectionString)
        {
            return @"
            public class clsDataAccessSettings{
            public static string ConnectionString="+"\""+ConnectionString+"\""+";\n" +
            "}" +
            "}";
        }
        static string GenerateTheMainClass(string TableName)
        {
            return $@"public class cls{TableName}
             "+@"{
              ";
        }

        public static void GenerateDataAccessSetting()
        {
            string DataBaseName = clsSettings.DBName;
            string ConnectString=clsDataAccessSettings.ConnectionString;
            File.WriteAllText($"C:/Users/Laptop Home/Desktop/Doucement/Code_Generator/clsDataAccessSettings.cs", GenerateTheHeader(DataBaseName)+ GenerateTheClassOfSettings(ConnectString));

        }
        static string GetCommandValues(List<clsColumn> ColList)
        {
            return string.Join(Environment.NewLine, ColList.Where(c => !c.IsPrimaryKey)
               .Select(c=>$"command.Parameters.AddWithValue(\"{c.Name}\",{c.Name});"));

        }
        static string GetTheSetClauseInUpdateOperation(List<clsColumn> ColList)
        {
            return string.Join(", ", ColList.Where(c => !c.IsPrimaryKey)
               .Select(c => $"{c.Name} = @{c.Name}"));

        }
        
      static string GetParameterList(List<clsColumn>ColList,bool IsWithDataType=false,bool IsColValue=false, bool IsInInserting=false)
        {
            List<string> parameters = new List<string>();
            
            foreach (clsColumn col in ColList)
            {
                if(IsInInserting)
                if (col.IsPrimaryKey)
                    continue;

                if (IsWithDataType)
                    parameters.Add($"{col.CSharpType} {col.Name}");
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
        //public static void GenerateInsertForTable(string TableName,bool IsInserting)
        //{
            
            
        //    clsTableLogic Table = new clsTableLogic(TableName);
        //    string Parmeters = GetParameterList(Table.ColumnsList,true,false, IsInserting);
        //    string Content = GenerateTheHeader(clsSettings.DBName);
        //    clsColumn PrimaryKey = Table.GetPrimaryKey();
        //    string FileContent = File.ReadAllText("C:\\Users\\Laptop Home\\Desktop\\Doucement\\Code_Generator_Tempelate_Files\\UpdateOperation.txt");
        //    FileContent = FileContent.Replace("{TableName}", TableName);
        //    FileContent = FileContent.Replace("{ParameteList}",Parmeters);
        //    FileContent = FileContent.Replace("{Commands}", GetCommandValues(Table.ColumnsList));
        //    FileContent=FileContent.Replace("{Col}",GetParameterList(Table.ColumnsList,false,false, IsInserting));
        //    FileContent = FileContent.Replace("{ColValue}", GetParameterList(Table.ColumnsList, false, true,IsInserting));
        //    if(PrimaryKey!=null)
        //    FileContent = FileContent.Replace("{PrimaryKeyID}",PrimaryKey?.Name??"");
        //    FileContent = FileContent + "\n}";
        //    File.WriteAllText("c.cs", Content+FileContent);
        //}
        static void SetMethodFeature(ref string FileContent,clsTableLogic Table,clsColumn PrimaryKey,bool IsInserting)
        {
            string Parmeters = GetParameterList(Table.ColumnsList, true, false, IsInserting);
            FileContent = FileContent.Replace("{TableName}", Table.TableName);
            FileContent = FileContent.Replace("{ParameteList}", Parmeters);
            FileContent = FileContent.Replace("{Commands}", GetCommandValues(Table.ColumnsList));
            if (PrimaryKey != null)
                FileContent = FileContent.Replace("{PrimaryKeyID}", PrimaryKey?.Name ?? "");
            ;
        }
        
        public static string GenerateInsertMethod(clsTableLogic Table, clsColumn PrimaryKey)
        {
           
            string FileContent = File.ReadAllText("CRUD Operation\\AddOperation.txt");
            SetMethodFeature(ref FileContent, Table, PrimaryKey,true); 
            FileContent = FileContent.Replace("{Col}", GetParameterList(Table.ColumnsList, false, false, true));
            FileContent = FileContent.Replace("{ColValue}", GetParameterList(Table.ColumnsList, false, true, true));
            return FileContent;
           

        }
        public static string GenerateUpdateMethod(clsTableLogic Table, clsColumn PrimaryKey)
        {
         string FileContent = File.ReadAllText("CRUD Operation\\UpdateOperation.txt");
        SetMethodFeature(ref FileContent, Table, PrimaryKey,false);
            FileContent = FileContent.Replace("{Col}", GetTheSetClauseInUpdateOperation(Table.ColumnsList));
            return FileContent;

        }
        public static void GenerateMethodOperation(string TableName)
        {

            clsTableLogic Table = new clsTableLogic(TableName);
            //string Parmeters = GetParameterList(Table.ColumnsList, true, false);
            string Content = GenerateTheHeader(clsSettings.DBName);
            string MainClass = GenerateTheMainClass(TableName);
            clsColumn PrimaryKey = Table.GetPrimaryKey();
            string Methods=GenerateInsertMethod(Table, PrimaryKey)+GenerateUpdateMethod(Table,PrimaryKey);
            File.WriteAllText($"C:/Users/Laptop Home/Desktop/Doucement/Code_Generator/cls{TableName}Data.cs", Content + MainClass+Methods+"\n}\n}");

        }

    }
}
