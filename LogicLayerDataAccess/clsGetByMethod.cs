using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsGetByMethod:clsGenerateMethod
    {
        string ParametersWithDataType { get; set; }
        string WhereClause { get; set; }
        string GetByColumnNames { get; set; } 
        string strGetByColumns {  get; set; }
        List<clsColumn> GetByColumns { get; set; }
        List<clsColumn> RefColumns {  get; set; }
        string GetByColumnsWithDataType {  get; set; }
        public clsGetByMethod(clsTableLogic Table,clsCustomGetBy CustomGetBy, string TemplatePath):base(Table,TemplatePath)
        {

            
            RefColumns = Roles.GetByCols(CustomGetBy);
            GetByColumns = Table.ColumnsList.Where(c => !RefColumns.Contains(c)).Select(c=>c).ToList();
            ParametersWithDataType = string.Join(" ,", RefColumns.Select(c => $"ref {c.CSharpType} {c.Name}"));
            GetByColumnNames = string.Join("And",GetByColumns.Select(c=>c.Name));
            strGetByColumns = string.Join(" ,", GetByColumns.Select(c => $"{c.CSharpType} {c.Name}"));
            WhereClause = string.Join(" And ", GetByColumns.Select(c => $"{c.Name}=@{c.Name }"));
            GetByColumnsWithDataType= string.Join("", GetByColumns.Select(c => $"{c.Name}"));
            
            


        }
        protected override void ReplaceTemplatePlaceHolderValue()
        {
            base.ReplaceTemplatePlaceHolderValue();
            TemplateContent.Replace("{ParameteList}", ParametersWithDataType);
            TemplateContent.Replace("{InputParameters}", strGetByColumns);
            TemplateContent.Replace("{Col}", GetByColumnsWithDataType);
            TemplateContent.Replace("{ConvertObjectToValues}",clsGlobal.GetObjectConverted(RefColumns));
            TemplateContent.Replace("{WhereClause}", WhereClause);
            TemplateContent.Replace("{ColumnNames}", GetByColumnNames);
            TemplateContent.Replace("{Commands}", clsGlobal.GetCommandValues(GetByColumns));
            TemplateContent.Replace("{FindVariablesDeclaration}", string.Join(" ;", RefColumns.Select(c => $"{c.CSharpType} {c.Name}={clsUtil.GetDefaultValue(c.CSharpType)}")));
            TemplateContent.Replace("{InputParametersWithoutDataType}", string.Join(" ,", GetByColumns.Select(c=>$"{c.Name}")));
            TemplateContent.Replace("{refParametListWithoutDataType}", string.Join(" ,", RefColumns.Select(c => $"ref {c.Name}")));
            TemplateContent.Replace("{ConstructorParameter}",string.Join(" ,", Table.ColumnsList.Select(c => $"{c.Name}")));
        }
        
    }
}
