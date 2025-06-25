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
            //ColumnsList = clsColumnData.GetColumnsForTable(tableName);
        }
        public static async Task<clsTableLogic> CreateAsync(string tableName)
        {
            var tableLogic = new clsTableLogic(tableName);
            tableLogic.ColumnsList = await clsColumnData.GetColumnsForTable(tableName);
            return tableLogic;
        }

        public clsColumn GetPrimaryKey()
        {
            return ColumnsList?.Find(col => col.IsPrimaryKey);
        }
    }
}
