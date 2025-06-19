using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicLayerDataAccess
{
    public class clsBussinessLayer_Generator
    {
        static clsColumnRoles columnRoles;
        public static string MethodsPath;
        public static void GenerateInsertMethod(clsTableLogic Table, StringBuilder Content)
        {

            clsInsertMethod insertMethod = new clsInsertMethod(Table, "CRUD Operation\\Bussines Layer Templates\\AddOperation.txt");
            Content.Append(insertMethod.GenerateMethod());
        }
        static void GenerateConustructsAndProprites(clsTableLogic Table,StringBuilder Content)
        {
            clsLogicLayerConstructorAndProprietes logicLayerConstructorAndProprietes = new clsLogicLayerConstructorAndProprietes(Table, "CRUD Operation\\Bussines Layer Templates\\ConstructorsAndProprites.txt");
            Content.Append(logicLayerConstructorAndProprietes.GenerateMethod());
        }
        public static void GenerateUpdateMethod(clsTableLogic Table, StringBuilder Content)
        {
            clsUpdateMethod updateMethod = new clsUpdateMethod(Table, "CRUD Operation\\Bussines Layer Templates\\UpdateOperation.txt");
            Content.Append(updateMethod.GenerateMethod());
        }
        static void GenerateSaveMethod(clsTableLogic Table,StringBuilder Content)
        {
            clsSaveMethodforLogicLayer saveMethodforLogicLayer=new clsSaveMethodforLogicLayer(Table, "CRUD Operation\\Bussines Layer Templates\\SaveMethod.txt");
            Content.Append(saveMethodforLogicLayer.GenerateMethod());
        }
        static void GenerateMethods(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder Method)
        {
            columnRoles = new clsColumnRoles(Table);
            GenerateConustructsAndProprites(Table, Method);
            GenerateInsertMethod(Table, Method);
            GenerateUpdateMethod(Table, Method);
            GenerateGetAllOperation(Table, Method);
            GenerateSaveMethod(Table,Method);
            
        }
        public static void GenerateMethodOperation(clsTableLogic Table, List<clsCustomGetBy> CustomsFunctions)
        {
            StringBuilder Content = new StringBuilder();
            clsColumn PrimaryKey = Table.GetPrimaryKey();
            StringBuilder Method = new StringBuilder();
            Content.Append(clsGlobal.GetTheBussinessClassInfo(clsSettings.DBName, Table.TableName));
            GenerateMethods(Table, PrimaryKey, Method);
            for (int i = 0; i < CustomsFunctions.Count; i++)
            {
                GenerateCustom(Table, CustomsFunctions[i],Method);
            }
            Content.Append(Method);
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/cls{Table.TableName}.cs", Content + "\n}\n}");
            Content = new StringBuilder();

        }
        public static void GenerateDeleteOperation(clsTableLogic Table, clsCustomGetBy DeleteBy, StringBuilder Content)
        {

            clsGetByMethod DeleteByMethod = new clsGetByMethod(Table, DeleteBy, "CRUD Operation\\Bussines Layer Templates\\DeleteOperation.txt");

            Content.Append(DeleteByMethod.GenerateMethod());
        }

        public static void GenerateGetByIDOperation(clsTableLogic Table, clsCustomGetBy GetBy, StringBuilder Content)
        {
            clsGetByMethod clsGetBy = new clsGetByMethod(Table, GetBy, "CRUD Operation\\Bussines Layer Templates\\GetByOperation.txt");
            Content.Append(clsGetBy.GenerateMethod());
        }
        public static void GenerateCustom(clsTableLogic Table, clsCustomGetBy getBy, StringBuilder Content)
        {
            if (getBy.MethodType == clsCustomGetBy.enMethods.GetBy)
                GenerateGetByIDOperation(Table, getBy,Content);
            else if (getBy.MethodType == clsCustomGetBy.enMethods.DeleteBy)
                GenerateDeleteOperation(Table, getBy, Content);
        }
        public static void GenerateGetAllOperation(clsTableLogic Table, StringBuilder Content)
        {
            if (Table == null) return;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText("CRUD Operation\\Bussines Layer Templates\\GetAll.txt"));
            FileContent.Replace("{TableName}", Table.TableName);
            Content.Append(FileContent);
        }
    }
}
