using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection =
                new SqlConnection(@"Server=.;User Id=sa;Password=5048Vlad;Database=MinionsDB;MultipleActiveResultSets=True;TrustServerCertificate=True");
            await connection.OpenAsync();

            SqlCommand sqlCommand = 
                new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinions, connection);

            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while(reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                Console.WriteLine($"{villainName} - {minionsCount}");
            }
        }
    }
}