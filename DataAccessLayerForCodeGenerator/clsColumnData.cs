using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloblalLibrary;
namespace DataAccessLayerForCodeGenerator
{
    public class clsColumnData
    {

        public async static Task<List<clsColumn>> GetColumnsForTable(string tableName)
        {
            var columns = new List<clsColumn>();
            string connectionString = clsDataAccessSettings.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    COLUMN_NAME, 
                    DATA_TYPE, 
                    IS_NULLABLE, 
                    COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity,
                    ORDINAL_POSITION,
       CASE 
        WHEN DATA_TYPE IN ('int') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'int?' ELSE 'int' END
        WHEN DATA_TYPE IN ('bigint') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'long?' ELSE 'long' END
        WHEN DATA_TYPE IN ('smallint') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'short?' ELSE 'short' END
        WHEN DATA_TYPE IN ('tinyint') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'byte?' ELSE 'byte' END
        WHEN DATA_TYPE IN ('bit') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'bool?' ELSE 'bool' END
        WHEN DATA_TYPE IN ('decimal', 'numeric', 'money', 'smallmoney') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'decimal?' ELSE 'decimal' END
        WHEN DATA_TYPE IN ('float') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'double?' ELSE 'double' END
        WHEN DATA_TYPE IN ('real') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'float?' ELSE 'float' END
        WHEN DATA_TYPE IN ('date', 'datetime', 'datetime2', 'smalldatetime', 'time') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'DateTime?' ELSE 'DateTime' END
        WHEN DATA_TYPE IN ('char', 'varchar', 'text', 'nchar', 'nvarchar', 'ntext') THEN 'string'
        WHEN DATA_TYPE IN ('uniqueidentifier') THEN CASE WHEN IS_NULLABLE = 'YES' THEN 'Guid?' ELSE 'Guid' END
        WHEN DATA_TYPE IN ('binary', 'varbinary', 'image') THEN 'byte[]'
        ELSE 'object'
    END AS CSharpType
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = @TableName
                ORDER BY ORDINAL_POSITION";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableName", tableName);

                await conn.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string columnName = reader["COLUMN_NAME"].ToString();
                        string dataType = reader["DATA_TYPE"].ToString();
                        bool isNullable = reader["IS_NULLABLE"].ToString() == "YES";
                        bool isPrimaryKey = Convert.ToInt32(reader["IsIdentity"]) == 1;
                        int position = Convert.ToInt32(reader["ORDINAL_POSITION"]);
                        string CSharpType = reader["CSharpType"].ToString();

                        columns.Add(new clsColumn(columnName, dataType, isPrimaryKey, isNullable, position, CSharpType));
                    }
                }
            }

            return columns;
        }
    }
}

