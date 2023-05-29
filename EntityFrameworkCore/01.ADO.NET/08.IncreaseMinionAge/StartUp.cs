using _01.InitialSetup;
using Microsoft.Data.SqlClient;


namespace _08.IncreaseMinionAge
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            int[] minionsId = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < minionsId.Length; i++)
            {
                await IncreaseMinionAge(connection, minionsId[i]);
            }

            await PrintMinions(connection);
        }

        private async static Task PrintMinions(SqlConnection connection)
        {
            SqlCommand printMinionsCmd =
                new SqlCommand(SqlQueries.GetAllMinionsNameAndAge, connection);
            SqlDataReader reader = await printMinionsCmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];

                Console.WriteLine($"{name} {age}");
            }
        }

        private static async Task IncreaseMinionAge(SqlConnection connection, int minionId)
        {
            SqlCommand increaseMiniongAgeCmd =
                new SqlCommand(SqlQueries.IncreaseMinionAge, connection);
            increaseMiniongAgeCmd.Parameters.AddWithValue("@Id", minionId);

            await increaseMiniongAgeCmd.ExecuteNonQueryAsync();
        }
    }
}