using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsLogicLayerConstructorAndProprietes:clsGenerateMethod
    {
        public clsLogicLayerConstructorAndProprietes(clsTableLogic Table, string TemplatePath):base (Table,TemplatePath)
        {
            this.Table = Table;
            this.TableName = Table.TableName;
            TemplateContent = new StringBuilder(clsCrudTemplate.LoadTemplate(TemplatePath));
            PrimaryKey = Table.GetPrimaryKey();
        }
      protected override void ReplaceTemplatePlaceHolderValue()
        {
            base.ReplaceTemplatePlaceHolderValue();
            TemplateContent.Replace("{Proprites}", string.Join(Environment.NewLine,Table.ColumnsList.Select(c=>$"public {c.CSharpType} {c.Name} {{get;set;}}")));
            TemplateContent.Replace("{ParameterList}", string.Join(" ,", Table.ColumnsList.Select(c => $"{c.CSharpType} {c.Name}")));
            TemplateContent.Replace("{ParameterizedAssignments}", string.Join(Environment.NewLine, Table.ColumnsList.Select(c => $"this.{c.Name}={c.Name};")));
            TemplateContent.Replace("{DefaultConstructorValue}" , string.Join(Environment.NewLine, Table.ColumnsList.Select(c => $"this.{c.Name}={clsUtil.GetDefaultValue(c.CSharpType)};")));
        }
    }
}
