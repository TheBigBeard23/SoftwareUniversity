using _01.InitialSetup;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection =
                new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string? villain = await GetVillain(villainId, connection);

            if (villain != null)
            {
                await DeleteVillainMinions(villain, villainId, connection);
            }
            else
            {
                Console.WriteLine("No such villain was found.");
            }

        }

        private static async Task DeleteVillainMinions(string villain, int villainId, SqlConnection connection)
        {
            SqlCommand deleteVillainCmd = new SqlCommand(SqlQueries.DeleteMinionsFromVillain, connection);
            deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            int minionsCount = await deleteVillainCmd.ExecuteNonQueryAsync();

            await DeleteVillain(villainId, connection);

            Console.WriteLine($"{villain} was deleted.");
            Console.WriteLine($"{minionsCount} minions were released.");
        }

        private static async Task DeleteVillain(int villainId, SqlConnection connection)
        {
            SqlCommand deleteVillainCmd = new SqlCommand(SqlQueries.DeleteVillain, connection);
            deleteVillainCmd.Parameters.AddWithValue("villainId", villainId);

            await deleteVillainCmd.ExecuteNonQueryAsync();
        }

        private static async Task<string?> GetVillain(int villainId, SqlConnection connection)
        {
            SqlCommand getVillainCmd = new SqlCommand(SqlQueries.GetVillain, connection);
            getVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            return (string?)await getVillainCmd.ExecuteScalarAsync();

        }
    }
}