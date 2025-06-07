using DataAccessLayerForCodeGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerDataAccess
{
    public class clsDataBasesLogic
    {
        public static string DBName { get { return clsSettings.DBName; } set { value = clsSettings.DBName; } }
        public static DataTable GetAllDataBases()
        {
            return clsDataBases.GetDataBasesList();
        }
    }
}
