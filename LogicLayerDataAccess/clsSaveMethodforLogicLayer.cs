using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsSaveMethodforLogicLayer:clsGenerateMethod
    {
        public clsSaveMethodforLogicLayer(clsTableLogic Table, string TemplatePath):base(Table,TemplatePath)
        {
      


        }
        protected override void ReplaceTemplatePlaceHolderValue()
        {
            base.ReplaceTemplatePlaceHolderValue();

        }
    }
}
