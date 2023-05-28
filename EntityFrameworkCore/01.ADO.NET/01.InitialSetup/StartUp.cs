using Microsoft.Data.SqlClient;
using System.Net.Http.Headers;

namespace _01.InitialSetup
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString(""));
            await connection.OpenAsync();

            ExecNonQuery(SqlQueries.CreateDatabase, connection);

            await connection.CloseAsync();

            connection.ConnectionString = Configuration.GetConnectionString("MinionsDB");

            await connection.OpenAsync();

            foreach (var statement in SqlQueries.createDatabaseTables)
            {
                ExecNonQuery(statement, connection);                
            }

            foreach (var statement in SqlQueries.insertValuesIntoTables)
            {
                ExecNonQuery(statement, connection);
            }

        }
        private static void ExecNonQuery(string cmdText, SqlConnection connection)
        {
            using (var command = new SqlCommand(cmdText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}