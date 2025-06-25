using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicLayerDataAccess
{
    public class clsGenerator
    {
        public enum enGenerateType { DataAccess,Bussines}
         clsColumnRoles columnRoles { get; set; }
        string MethodsPath{  get; set; }
        string ClassesNamePostfix {  get; set; }
        public enGenerateType GenerateType {  get; set; }
        string[] TemplatePathes {  get; set; }
        string ReferencedLayerFolder  { get; set; }
        private enum TemplateMapping
        {
            Add,
            Update,
            Delete,
            IsExistingBy,
            GetBy,
            GetAll,
            ConstructorsAndProperties,
            Save
        }
        public clsGenerator(enGenerateType generateType,string MethodPath,string ReferencedLayerFolder ="")
        {
            
            GenerateType = generateType; 
            MethodsPath= MethodPath;
            if (GenerateType == enGenerateType.DataAccess)
            {
                TemplatePathes = new string[] { "CRUD Operation\\AddOperation.txt" ,
                    "CRUD Operation\\UpdateOperation.txt", "CRUD Operation\\DeleteOperation.txt", "CRUD Operation\\IsExistingByOperation.txt"
                    , "CRUD Operation\\GetByPrimaryKey.txt", "CRUD Operation\\GetAllOperation.txt" };
                ClassesNamePostfix = "Data";
            }
            else
            {
                TemplatePathes = new string[] { "CRUD Operation\\Bussines Layer Templates\\AddOperation.txt", "CRUD Operation\\Bussines Layer Templates\\UpdateOperation.txt", 
                    "CRUD Operation\\Bussines Layer Templates\\DeleteOperation.txt", "CRUD Operation\\Bussines Layer Templates\\IsExistingByOperation.txt"
                    , "CRUD Operation\\Bussines Layer Templates\\GetByOperation.txt", 
                    "CRUD Operation\\Bussines Layer Templates\\GetAll.txt", "CRUD Operation\\Bussines Layer Templates\\ConstructorsAndProprites.txt", 
                    "CRUD Operation\\Bussines Layer Templates\\SaveMethod.txt" };
                this.ReferencedLayerFolder  = ReferencedLayerFolder ;
           }
        }
        string _GenerateDataAccsessSetting()
        {
            string DataBaseName = clsSettings.DBName;
            return clsGlobal.GetTheDataSettingInfo(DataBaseName, new DirectoryInfo(MethodsPath).Name);
        }
        void GenerateDataAccessSetting()
        {
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/clsDataAccessSettings.cs", _GenerateDataAccsessSetting());
        }
        void GenerateInsertMethod(clsTableLogic Table, StringBuilder Content)
        {

            clsInsertMethod insertMethod = new clsInsertMethod(Table, TemplatePathes[(int)TemplateMapping.Add]);
            Content.Append(insertMethod.GenerateMethod());
        }
         void GenerateConustructsAndProprites(clsTableLogic Table,StringBuilder Content)
        {
            clsLogicLayerConstructorAndProprietes logicLayerConstructorAndProprietes = new clsLogicLayerConstructorAndProprietes(Table, TemplatePathes[(int)TemplateMapping.ConstructorsAndProperties]);
            Content.Append(logicLayerConstructorAndProprietes.GenerateMethod());
        }
         void GenerateUpdateMethod(clsTableLogic Table, StringBuilder Content)
        {
            clsUpdateMethod updateMethod = new clsUpdateMethod(Table, TemplatePathes[(int)TemplateMapping.Update]);
            Content.Append(updateMethod.GenerateMethod());
        }
        void GenerateSaveMethod(clsTableLogic Table,StringBuilder Content)
        {
            clsSaveMethodforLogicLayer saveMethodforLogicLayer=new clsSaveMethodforLogicLayer(Table, TemplatePathes[(int)TemplateMapping.Save]);
            Content.Append(saveMethodforLogicLayer.GenerateMethod());
        }
        void GenerateIsExistingMethod(clsTableLogic Table, clsCustomGetBy IsExistingBy, StringBuilder Content)
        {
            clsGetByMethod IsExistingByMethod = new clsGetByMethod(Table, IsExistingBy, TemplatePathes[(int)TemplateMapping.IsExistingBy]);

            Content.Append(IsExistingByMethod.GenerateMethod());
        }
         void GenerateMethods(clsTableLogic Table, clsColumn PrimaryKey, StringBuilder Method)
        {
            columnRoles = new clsColumnRoles(Table);
            if(GenerateType==enGenerateType.Bussines)
                GenerateConustructsAndProprites(Table, Method);
            GenerateInsertMethod(Table, Method);
            GenerateUpdateMethod(Table, Method);
            GenerateGetAllOperation(Table, Method);
            if (GenerateType == enGenerateType.Bussines)
                GenerateSaveMethod(Table,Method);
            
        }
        public void GenerateMethodOperation(clsTableLogic Table, List<clsCustomGetBy> CustomsFunctions)
        {
            StringBuilder Content = new StringBuilder();
            clsColumn PrimaryKey = Table.GetPrimaryKey();
            StringBuilder Method = new StringBuilder();
            if(GenerateType==enGenerateType.Bussines)
            Content.Append(clsGlobal.GetTheBussinessClassInfo(clsSettings.DBName, Table.TableName,new DirectoryInfo(MethodsPath).Name, new DirectoryInfo(ReferencedLayerFolder ).Name));
            else
            {
                Content.Append(clsGlobal.GetTheDataAccessClassInfo(clsSettings.DBName, Table.TableName, new DirectoryInfo(MethodsPath).Name));
                GenerateDataAccessSetting();
            }
            GenerateMethods(Table, PrimaryKey, Method);
            for (int i = 0; i < CustomsFunctions.Count; i++)
            {
                GenerateCustom(Table, CustomsFunctions[i],Method);
            }
            Content.Append(Method);
            clsCrudTemplate.SaveTemplate($"{MethodsPath}/cls{Table.TableName}{ClassesNamePostfix}.cs", Content + "\n}\n}");
            Content = new StringBuilder();

        }
        void GenerateDeleteOperation(clsTableLogic Table, clsCustomGetBy DeleteBy, StringBuilder Content)
        {

            clsGetByMethod DeleteByMethod = new clsGetByMethod(Table, DeleteBy, TemplatePathes[(int)TemplateMapping.Delete]);

            Content.Append(DeleteByMethod.GenerateMethod());
        }

         void GenerateGetByIDOperation(clsTableLogic Table, clsCustomGetBy GetBy, StringBuilder Content)
        {
            clsGetByMethod clsGetBy = new clsGetByMethod(Table, GetBy, TemplatePathes[(int)TemplateMapping.GetBy]);
            Content.Append(clsGetBy.GenerateMethod());
        }
        void GenerateCustom(clsTableLogic Table, clsCustomGetBy getBy, StringBuilder Content)
        {
            if (getBy.MethodType == clsCustomGetBy.enMethods.GetBy)
                GenerateGetByIDOperation(Table, getBy, Content);
            else if (getBy.MethodType == clsCustomGetBy.enMethods.DeleteBy)
                GenerateDeleteOperation(Table, getBy, Content);
            else
                GenerateIsExistingMethod(Table, getBy, Content);
        }
        void GenerateGetAllOperation(clsTableLogic Table, StringBuilder Content)
        {
            if (Table == null) return;
            StringBuilder FileContent = new StringBuilder(File.ReadAllText(TemplatePathes[(int)TemplateMapping.GetAll]));
            FileContent.Replace("{TableName}", Table.TableName);
            Content.Append(FileContent);
        }
    }
}
