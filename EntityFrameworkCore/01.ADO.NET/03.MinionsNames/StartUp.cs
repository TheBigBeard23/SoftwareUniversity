using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _03.MinionsNames
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainCmd = new SqlCommand(SqlQueries.GetVillainById, connection);
            getVillainCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainName = await getVillainCmd.ExecuteScalarAsync();

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {(string)villainName}");
                Console.WriteLine(await GetMinionsByVillainId(villainId, connection));
            }
        }

        private static async Task<string> GetMinionsByVillainId(int villainId, SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            
            SqlCommand getMinions = new SqlCommand(SqlQueries.GetMinionsByVillainId, connection);
            getMinions.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader reader = await getMinions.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (reader.Read())
                {
                    long row = (long)reader["RowNum"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    sb.AppendLine($"{row}. {name} {age}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}