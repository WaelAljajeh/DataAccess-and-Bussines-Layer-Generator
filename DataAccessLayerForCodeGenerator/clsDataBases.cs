using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerForCodeGenerator
{
    public class clsDataBases
    {
        public static DataTable GetDataBasesList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Select * from sys.DataBases";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        dt = null;
                        Console.WriteLine("Error " + ex.ToString());
                    }
                    finally { connection.Close(); }
                    return dt;
                }
            }
        }
    }
}
