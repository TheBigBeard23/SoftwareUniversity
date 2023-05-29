using _01.InitialSetup;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            int minionId = int.Parse(Console.ReadLine());

            await IncreaseMinionAge(minionId, connection);
            await PrintMinionInfo(connection, minionId);

        }

        private static async Task PrintMinionInfo(SqlConnection connection, int minionId)
        {
            SqlCommand getMinionCmd = new SqlCommand(SqlQueries.GetMinion, connection);
            getMinionCmd.Parameters.AddWithValue("@Id", minionId);

            SqlDataReader reader = await getMinionCmd.ExecuteReaderAsync();

            reader.Read();

            string name = (string)reader["Name"];
            int age = (int)reader["Age"];

            Console.WriteLine($"{name} – {age} years old");
        }

        private static async Task IncreaseMinionAge(int minionId, SqlConnection connection)
        {
            SqlCommand increaseMinionAgeCmd =
                new SqlCommand(SqlQueries.IncreaseMinionAge, connection);
            increaseMinionAgeCmd.Parameters.AddWithValue("@Id", minionId);

            await increaseMinionAgeCmd.ExecuteNonQueryAsync();
        }
    }
}