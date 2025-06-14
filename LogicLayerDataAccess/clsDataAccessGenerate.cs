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
        
        public  delegate void OnOperationGenerator(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder FileContent);
        public static OnOperationGenerator OnOperationExecuted;
        static clsColumnRoles columnRoles;
        public static string MethodsPath;
 
        static string _GenerateDataAccsessSetting()
        {
            string DataBaseName = clsSettings.DBName;
            return clsGlobal.GetTheDataSettingInfo(DataBaseName);
        }
        public static void GenerateDataAccessSetting()
        {
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/clsDataAccessSettings.cs", _GenerateDataAccsessSetting());
        }
        public static void GenerateInsertMethod(clsTableLogic Table, clsColumn PrimaryKey,StringBuilder Content)
        {
            
            string FileContentString= File.ReadAllText("CRUD Operation\\AddOperation.txt");
            StringBuilder FileContent = new StringBuilder(FileContentString);
            Table.ColumnsList = columnRoles.InsertCols;
            FileContent.Replace("{Col}",clsGlobal.GetParameterList(Table.ColumnsList, false, false));
            FileContent.Replace("{ColValue}", clsGlobal.GetParameterList(Table.ColumnsList, false, true));
            clsGlobal.SetCommonCrudTemplateValues(FileContent, Table, PrimaryKey);
            Content.Append(FileContent);
        }
        public static void GenerateUpdateMethod(clsTableLogic Table, clsColumn PrimaryKey,StringBuilder Content)
        {
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\UpdateOperation.txt"));
            Table.ColumnsList = columnRoles.UpdateCols;
            clsGlobal.SetCommonCrudTemplateValues( FileContent, Table, PrimaryKey);
            FileContent.Replace("{Col}", clsGlobal.GetTheSetClauseInUpdateOperation(Table.ColumnsList));
            Content.Append(FileContent);
        }
        static void GenerateMethods(clsTableLogic Table,clsColumn PrimaryKey,StringBuilder Method)
        {
            columnRoles = new clsColumnRoles(Table);
            GenerateInsertMethod(Table, PrimaryKey, Method);
            GenerateUpdateMethod(Table, PrimaryKey, Method);
            GenerateDeleteOperation(Table, PrimaryKey, Method);
            GenerateGetByIDOperation(Table, PrimaryKey, Method);
            GenerateGetAllOperation(Table, Method);
        }
        public static void GenerateMethodOperation(clsTableLogic Table)
        {
            
            StringBuilder Content = new StringBuilder();
            Content.Append(clsGlobal.GetTheClassInfo(clsSettings.DBName,Table.TableName));
            clsColumn PrimaryKey = Table.GetPrimaryKey();
            StringBuilder Method=new StringBuilder();
            GenerateMethods(Table, PrimaryKey, Method);
            Content.Append(Method);
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/cls{Table.TableName}Data.cs", Content +"\n}\n}");
        }
        public static void GenerateDeleteOperation(clsTableLogic Table,clsColumn PrimaryKey,StringBuilder Content)
        {
            if (PrimaryKey == null)
                return ;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\DeleteOperation.txt"));
            clsGlobal.SetCommonCrudTemplateValues( FileContent, Table, PrimaryKey);
            FileContent.Replace("{Type}", PrimaryKey.CSharpType);
            Content.Append(FileContent);
        }
     
        public static void GenerateGetByIDOperation(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder Content)
        {
            if (PrimaryKey == null)
                return;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\GetByPrimaryKey.txt"));
            FileContent.Replace(" {ConvertObjectToValues}",clsGlobal.GetObjectConverted(Table.ColumnsList));
            FileContent.Replace("{ColumnNames}",string.Join("And",Table.ColumnsList.Where(c=>c.IsGetByEnabled).Select(c=>c.Name)));
            FileContent.Replace("{InputParameters}",string.Join(",",Table.ColumnsList.Where(c => c.IsGetByEnabled).Select(c => $"{c.CSharpType} {c.Name}")));
            FileContent.Replace("{WhereClause}", string.Join(" And ", Table.ColumnsList.Where(c => c.IsGetByEnabled).Select(c => $"{c.Name}=@{c.Name}")));
            FileContent.Replace("{Commands}",clsGlobal.GetCommandValues(Table.ColumnsList,true));
            Table.ColumnsList = columnRoles.GetByCols;
            clsGlobal.SetCommonCrudTemplateValues(FileContent, Table, PrimaryKey, "ref");
            Content.Append(FileContent);
        }
        public static void GenerateGetAllOperation(clsTableLogic Table,StringBuilder Content)
        {
            if (Table == null) return;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\GetAllOperation.txt"));
            FileContent.Replace("{TableName}", Table.TableName);
            Content.Append(FileContent);
        }

    }
}
