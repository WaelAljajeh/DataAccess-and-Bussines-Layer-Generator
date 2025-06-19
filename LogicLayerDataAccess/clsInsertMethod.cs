using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsInsertMethod:  clsGenerateMethod
    {
        string ParametersWithDataType {  get; set; }
       
        string ParametersWithoutDataType { get; set; }
    
        public clsInsertMethod(clsTableLogic Table,string TemplatePath):base(Table,TemplatePath) 
        {
            
            ParametersWithDataType = string.Join(" ,",Roles.InsertCols.Select(c=>$"{c.CSharpType} {c.Name}"));
            ParametersWithoutDataType= string.Join(" ,", Roles.InsertCols.Select(c=>c.Name));
           
            


        }
        protected override void ReplaceTemplatePlaceHolderValue()
        {
            
            base.ReplaceTemplatePlaceHolderValue();
            TemplateContent.Replace("{ParameteList}", ParametersWithDataType);
            TemplateContent.Replace("{Col}", ParametersWithoutDataType) ;
            TemplateContent.Replace("{Commands}", clsGlobal.GetCommandValues(Roles.InsertCols));
            TemplateContent.Replace("{@Col}", string.Join(" ,", Roles.InsertCols.Select(c => $"@{c.Name}")));
        }
        
    }
}
