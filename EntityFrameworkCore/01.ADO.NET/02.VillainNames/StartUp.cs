using _01.InitialSetup;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            SqlCommand sqlCommand = 
                new SqlCommand(SqlQueries.GetVillainAndMinionsCount,connection);    
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];
                Console.WriteLine($"{name} - {minionsCount}");
            }
        }
    }
}