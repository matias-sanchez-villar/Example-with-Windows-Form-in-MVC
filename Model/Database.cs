using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Database
    {
        private string _connectionString = @"Server=LAPTOP-PB122MIC\SQLEXPRESS;Database=EjemploMVC;Trusted_Connection=True;";

        // Método para hacer una consulta SELECT
        public DataTable Select(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Si hay parámetros, los agregamos al comando
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // Crear un DataAdapter para llenar el DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        // Método para hacer un INSERT, UPDATE o DELETE
        public int ExecuteNonQuery(string query, SqlParameter[] sqlParams)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (sqlParams != null)
                        command.Parameters.AddRange(sqlParams);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

    }
}
