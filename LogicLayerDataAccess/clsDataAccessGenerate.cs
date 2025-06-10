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
        
        //public  delegate void OnOperationGenerator(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder FileContent);
        //public static OnOperationGenerator OnOperationExecuted;

        //static bool IsInInserting=false;
        // static bool IsWithDataType = false;
        public static string MethodsPath;
      
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
            File.WriteAllText($"{MethodsPath}/clsDataAccessSettings.cs", GenerateTheHeader(DataBaseName)+ GenerateTheClassOfSettings(ConnectString));

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
        
      static string GetParameterList(List<clsColumn>ColList,bool IsWithDataType=false,bool IsColValue=false, bool IncludePrimaryKey = false,string prefix="")
        {
            List<string> parameters = new List<string>();
            
            foreach (clsColumn col in ColList)
            {
                if(IncludePrimaryKey)
                if (col.IsPrimaryKey)
                    continue;

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
        static void SetCommonCrudTemplateValues(StringBuilder FileContent,clsTableLogic Table,clsColumn PrimaryKey,bool IncludePrimaryKey,string prefix="")
        {
            StringBuilder Parmeters = new StringBuilder();
            Parmeters.Append(GetParameterList(Table.ColumnsList, true, false, IncludePrimaryKey, prefix));
            FileContent.Replace("{TableName}", Table.TableName);
            FileContent.Replace("{ParameteList}", Parmeters.ToString());
            FileContent.Replace("{Commands}", GetCommandValues(Table.ColumnsList));
            if (PrimaryKey != null)
                FileContent.Replace("{PrimaryKeyID}", PrimaryKey?.Name ?? "");
            ;
        }
        
        public static void GenerateInsertMethod(clsTableLogic Table, clsColumn PrimaryKey,StringBuilder Content)
        {
            string FileContentString= File.ReadAllText("CRUD Operation\\AddOperation.txt");
            StringBuilder FileContent = new StringBuilder(FileContentString); 
            SetCommonCrudTemplateValues( FileContent, Table, PrimaryKey,true); 
            FileContent.Replace("{Col}", GetParameterList(Table.ColumnsList, false, false, true));
            FileContent.Replace("{ColValue}", GetParameterList(Table.ColumnsList, false, true, true));
            Content.Append(FileContent);
           

        }
        public static void GenerateUpdateMethod(clsTableLogic Table, clsColumn PrimaryKey,StringBuilder Content)
        {
           StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\UpdateOperation.txt"));
            SetCommonCrudTemplateValues( FileContent, Table, PrimaryKey,false);
            FileContent.Replace("{Col}", GetTheSetClauseInUpdateOperation(Table.ColumnsList));
            Content.Append(FileContent);

        }
        public static void GenerateMethodOperation(string TableName)
        {
            StringBuilder Content = new StringBuilder();
            clsTableLogic Table = new clsTableLogic(TableName);
            //string Parmeters = GetParameterList(Table.ColumnsList, true, false);
            Content.Append(GenerateTheHeader(clsSettings.DBName));
            Content.Append(GenerateTheMainClass(TableName));
            clsColumn PrimaryKey = Table.GetPrimaryKey();
            StringBuilder Method=new StringBuilder();
            GenerateInsertMethod(Table, PrimaryKey, Method);
            GenerateUpdateMethod(Table, PrimaryKey, Method);
            GenerateDeleteOperation(Table, PrimaryKey, Method);
            GenerateGetByIDOperation(Table, PrimaryKey, Method);
            //OnOperationExecuted(Table, PrimaryKey,Method);
            Content.Append(Method);
            //Content.Append(GenerateUpdateMethod(Table, PrimaryKey));
            //Content.Append(GenerateDeleteOperation(Table,PrimaryKey));
            File.WriteAllText($"{MethodsPath}/cls{TableName}Data.cs", Content +"\n}\n}");

        }
        public static void GenerateDeleteOperation(clsTableLogic Table,clsColumn PrimaryKey,StringBuilder Content)
        {
            if (PrimaryKey == null)
                return ;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\DeleteOperation.txt"));
            SetCommonCrudTemplateValues( FileContent, Table, PrimaryKey, false);
            FileContent.Replace("{Type}", PrimaryKey.CSharpType);
            Content.Append(FileContent);
            
             
        }
       static string GetObjectConverted(List<clsColumn> ColList)
        {
            return string.Join(Environment.NewLine, ColList.Where(c => !c.IsPrimaryKey)
            .Select(c => $"{("{Value}= "+clsUtil.ConvertObjectToDataType(c)).Replace("{Value}",c.Name)};"));
        }
        public static void GenerateGetByIDOperation(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder Content)
        {
            if (PrimaryKey == null)
                return;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\GetByPrimaryKey.txt"));
            SetCommonCrudTemplateValues(FileContent, Table, PrimaryKey, true,"ref");
            FileContent.Replace(" {ConvertObjectToValues}",GetObjectConverted(Table.ColumnsList));
            FileContent.Replace("{Type}", PrimaryKey.CSharpType);
            Content.Append(FileContent);
            
        }

    }
}
