using DataAccessLayerForCodeGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloblalLibrary;

namespace LogicLayerDataAccess
{
    public class clsTableLogic
    {
        public string TableName;
        public List<clsColumn> ColumnsList { get; set; }
        public static DataTable GetAllTheTables()
        {
            return  clsTablesData.GetDataBaseTables();
        }
        public clsTableLogic(string tableName)
        {
            TableName = tableName;
            ColumnsList = clsColumnData.GetColumnsForTable(tableName);
        }

        public clsColumn GetPrimaryKey()
        {
            return ColumnsList?.Find(col => col.IsPrimaryKey);
        }
    }
}
