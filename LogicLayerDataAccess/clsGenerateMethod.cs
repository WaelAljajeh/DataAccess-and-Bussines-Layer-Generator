using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public abstract class clsGenerateMethod
    {
        protected clsTableLogic Table { get; set; }
        protected string TableName { get; set; }
        protected clsColumn PrimaryKey {  get; set; }
        protected clsColumnRoles Roles { get; set; }
        protected StringBuilder TemplateContent {  get; set; }
        protected clsGenerateMethod(clsTableLogic Table,string TemplatePath)
        {
            this.Table = Table;
            Roles = new clsColumnRoles(Table);
            this.TableName = Table.TableName;
            TemplateContent = new StringBuilder(clsCrudTemplate.LoadTemplate(TemplatePath));
            PrimaryKey = Table.GetPrimaryKey();

        }
        protected virtual void ReplaceTemplatePlaceHolderValue()
        {
            if (PrimaryKey == null)
                return;
            TemplateContent.Replace("{TableName}", TableName);
            TemplateContent.Replace("{PrimaryKeyID}", PrimaryKey.Name);
            
        }
        public StringBuilder GenerateMethod()
        {
            ReplaceTemplatePlaceHolderValue();
            return TemplateContent;
        }

    }
}
