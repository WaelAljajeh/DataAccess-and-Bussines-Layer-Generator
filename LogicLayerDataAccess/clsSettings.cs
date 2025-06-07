using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerForCodeGenerator;

namespace LogicLayerDataAccess
{
    public class clsSettings
    {
        private static string _dbConnectionString { get; set; }
        public static string DBUserName { get; set; }
        public static string DBPassword { get; set; }

        private static string _DBName = null;
        public static string DBName
        {
            get;
            set;
            
            
        }

        public static void SetConnectionString()
        {
            if(string.IsNullOrWhiteSpace(DBPassword)&&string.IsNullOrWhiteSpace(DBName))
            {
                
                return;
            }
            if(string.IsNullOrWhiteSpace(DBName))
            {
                _dbConnectionString = $"Server=.;user Id={DBUserName};Password={DBPassword}";
            }
            else
            {
                _dbConnectionString = $"Server=.;DataBase={DBName};user Id={DBUserName};Password={DBPassword}";
            }
            clsDataAccessSettings.ConnectionString = _dbConnectionString;
            
        }
        static string GetConnectionString()
        {
            return _dbConnectionString;
        }
    }
}
