using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsCustomGetBy
    {
        public enum enMethods { GetBy=1,DeleteBy=2,IsExistingBy=3}
        public List<clsColumn> GetByCols { get; set; }
        public enMethods MethodType { get; set; }
        public clsCustomGetBy()
        {
            MethodType = enMethods.GetBy;
            GetByCols = new List<clsColumn>();

        }
        public clsCustomGetBy(enMethods MethodType,clsTableLogic Table)
        {
            this.MethodType =MethodType ;
            GetByCols = new List<clsColumn>(Table.ColumnsList.Where(c=>c.IsPrimaryKey).Select(c=>c));

        }




    }
}
