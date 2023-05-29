using _01.InitialSetup;
using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await sqlConnection.OpenAsync();

            SqlCommand getAllMinionsCmd =
                new SqlCommand(SqlQueries.GetAllMinions, sqlConnection);

            SqlDataReader reader = await getAllMinionsCmd.ExecuteReaderAsync();

            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - i - 1]);
            }

            Console.WriteLine(minions[minions.Count / 2]);

        }
    }
}