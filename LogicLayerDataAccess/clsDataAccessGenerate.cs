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
       //static StringBuilder Content = new StringBuilder();
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
        public static void GenerateInsertMethod(clsTableLogic Table,StringBuilder Content)
        {

            clsInsertMethod insertMethod = new clsInsertMethod(Table, "CRUD Operation\\AddOperation.txt");
            Content.Append(insertMethod.GenerateMethod());
        }
        public static void GenerateUpdateMethod(clsTableLogic Table,StringBuilder Content)
        {
            clsUpdateMethod updateMethod = new clsUpdateMethod(Table, "CRUD Operation\\UpdateOperation.txt");
            Content.Append(updateMethod.GenerateMethod());
        }
        static void GenerateMethods(clsTableLogic Table,clsColumn PrimaryKey,StringBuilder Method)
        {
            columnRoles = new clsColumnRoles(Table);
            GenerateInsertMethod(Table, Method);
            GenerateUpdateMethod(Table, Method);
            //GenerateDeleteOperation(Table, columnRoles, PrimaryKey, Method);
            GenerateGetAllOperation(Table, Method);
        }
        public static void GenerateMethodOperation(clsTableLogic Table,List<clsCustomGetBy> CustomsFunctions)
        {

            clsColumn PrimaryKey = Table.GetPrimaryKey();
            StringBuilder Method = new StringBuilder();
            StringBuilder Content = new StringBuilder();
            Content.Append(clsGlobal.GetTheDataAccessClassInfo(clsSettings.DBName, Table.TableName));
            GenerateMethods(Table, PrimaryKey, Method);
            for (int i = 0; i < CustomsFunctions.Count; i++)
            {
                GenerateCustom(Table, CustomsFunctions[i], Method);
            }
            
            Content.Append(Method);
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/cls{Table.TableName}Data.cs", Content + "\n}\n}");
            Content = new StringBuilder();

        }
        public static void GenerateDeleteOperation(clsTableLogic Table,clsCustomGetBy DeleteBy,StringBuilder Content)
        {
            
            clsGetByMethod DeleteByMethod=new clsGetByMethod(Table,DeleteBy,"CRUD Operation\\DeleteOperation.txt");
            
            Content.Append(DeleteByMethod.GenerateMethod());
        }
     
        public static void GenerateGetByIDOperation(clsTableLogic Table,clsCustomGetBy GetBy, StringBuilder Content)
        {
            clsGetByMethod clsGetBy = new clsGetByMethod(Table,GetBy, "CRUD Operation\\GetByPrimaryKey.txt");
            Content.Append(clsGetBy.GenerateMethod());
        }
        public static void GenerateCustom(clsTableLogic Table, clsCustomGetBy getBy, StringBuilder Content)
        {
            if(getBy.MethodType==clsCustomGetBy.enMethods.GetBy)  
            GenerateGetByIDOperation(Table, getBy, Content);
            else if(getBy.MethodType==clsCustomGetBy.enMethods.DeleteBy)
            GenerateDeleteOperation(Table, getBy, Content);
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
