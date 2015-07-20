using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KTSql
{
    public class KTSql
    {
        public static DataTable ExecuteGetQuery(string connectionString, string query, List<SqlParameter> parameters)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var adapter = new SqlDataAdapter();
            var command = new SqlCommand(query, connection);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.DbType == DbType.Guid)
                    {
                        command.Parameters.Add(new SqlParameter
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier,
                            Value = parameter.Value,
                            ParameterName = parameter.ParameterName
                        });
                    }
                    else
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }
            var dataset = new DataSet();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dataset);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            connection.Close();

            return dataset.Tables[0];
        }

        public static void ExecuteEditQuery(string connectionString, string query, List<SqlParameter> parameters)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(query, connection);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
