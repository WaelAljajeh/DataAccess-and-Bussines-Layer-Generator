using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsUpdateMethod:clsGenerateMethod
    {
        string ParametersWithDataType { get; set; }
        string ParametersWithoutDataType { get; set; }
        public clsUpdateMethod(clsTableLogic Table, string TemplatePath):base(Table,TemplatePath) 
        {
            
            ParametersWithDataType = string.Join(" ,", Roles.UpdateCols.Select(c => $"{c.CSharpType} {c.Name}"));
            ParametersWithoutDataType = string.Join(" ,", Roles.UpdateCols.Select(c => c.Name));
           


        }
        protected override void ReplaceTemplatePlaceHolderValue()
        {
            base.ReplaceTemplatePlaceHolderValue();
            TemplateContent.Replace("{ParameteList}", ParametersWithDataType);
            TemplateContent.Replace("{Col}", ParametersWithoutDataType);
            TemplateContent.Replace("{SetClause}", clsGlobal.GetTheSetClauseInUpdateOperation(Roles.UpdateCols));
            TemplateContent.Replace("{Commands}", clsGlobal.GetCommandValues(Roles.UpdateCols));
            
        }
    }
}
