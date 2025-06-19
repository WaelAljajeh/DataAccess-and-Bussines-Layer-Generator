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
       public List<clsColumn> DeleteCols;
       List<clsColumn> _GetByCols ;
        clsTableLogic _Table;
        public clsColumnRoles(clsTableLogic Table)
        {
            _Table = Table;
            InsertCols=Table.ColumnsList.Where(c => !c.IsPrimaryKey).ToList();
            UpdateCols = Table.ColumnsList;
            DeleteCols=Table.ColumnsList;
        }
        public List<clsColumn> GetByCols(clsCustomGetBy GetBy)
        {
            return _Table.ColumnsList.Where(c=>!GetBy.GetByCols.Contains(c)).ToList();
        }

    }
}
