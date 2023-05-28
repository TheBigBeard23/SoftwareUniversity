using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _03.MinionNames
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection =
                new SqlConnection(Configuration.ConnectionString("MinionsDB"));
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCmd =
               new SqlCommand(SqlQueries.GetVillainNameById, connection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();

            if(villainNameObj == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database");
            }
            else
            {
                Console.WriteLine(await GetAllMinions(connection, villainId, villainNameObj));
            }


        }

        private static async Task<string> GetAllMinions(SqlConnection connection, int villainId, object? villainNameObj)
        {
            StringBuilder sb = new StringBuilder();

            string villainName = (string)villainNameObj;

            SqlCommand getAllMinionsCmd =
                new SqlCommand(SqlQueries.GetAllMinionsByVillainId, connection);
            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            sb.AppendLine($"Villain: {villainName}");

            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string name = (string)minionsReader["Name"];
                    int age = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {name} {age}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}