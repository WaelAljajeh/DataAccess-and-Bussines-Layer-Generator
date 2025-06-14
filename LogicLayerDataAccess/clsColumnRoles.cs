using GloblalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsColumnRoles
    {
       public List<clsColumn> InsertCols;
       public List<clsColumn> UpdateCols;
        List<clsColumn> DeleteCols;
       public List<clsColumn> GetByCols;
        public clsColumnRoles(clsTableLogic Table)
        {
            InsertCols=Table.ColumnsList.Where(c => !c.IsPrimaryKey).ToList();
            UpdateCols = Table.ColumnsList;
            GetByCols=Table.ColumnsList.Where(c=>!c.IsGetByEnabled).ToList();
        }

    }
}
