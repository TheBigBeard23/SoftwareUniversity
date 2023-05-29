using _01.InitialSetup;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection
                = new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            string[] minionInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split();

            string villainName = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];

            string townName = minionInfo[2];
            int age = int.Parse(minionInfo[1]);
            string minionName = minionInfo[0];

            SqlTransaction sqlTransaction = connection.BeginTransaction();

            try
            {
                int? townId = await GetTownId(townName, connection, sqlTransaction);
                int? villainId = await GetVillainId(villainName, connection, sqlTransaction);
                int? minionId = await GetMinionId(minionName, age, townId, connection, sqlTransaction);

                await AddMinionToVillain(minionId, villainId, minionName, villainName, connection, sqlTransaction);
                await sqlTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
            }

        }

        private static async Task AddMinionToVillain(int? minionId, int? villainId, string minionName, string villainName, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            SqlCommand addMinionToVillainCmd =
                 new SqlCommand(SqlQueries.AddMinionToVillain, connection, sqlTransaction);
            addMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinionToVillainCmd.ExecuteNonQueryAsync();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
        private static async Task<int?> GetMinionId(string minionName, int age, int? townId, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            SqlCommand getMinionId =
                new SqlCommand(SqlQueries.GetMinionId, connection, sqlTransaction);
            getMinionId.Parameters.AddWithValue("@Name", minionName);

            int? minionId = (int?)await getMinionId.ExecuteScalarAsync();

            if (minionId != null)
            {
                SqlCommand addMinion =
                    new SqlCommand(SqlQueries.AddMinion, connection, sqlTransaction);
                addMinion.Parameters.AddWithValue("@name", minionName);
                addMinion.Parameters.AddWithValue("@age", age);
                addMinion.Parameters.AddWithValue("@townId", townId);

                minionId = (int?)await getMinionId.ExecuteScalarAsync();
            }

            return minionId;
        }
        private static async Task<int?> GetTownId(string townName, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            SqlCommand getTownIdCmd =
                new SqlCommand(SqlQueries.GetTownId, connection, sqlTransaction);
            getTownIdCmd.Parameters.AddWithValue("@townName", townName);

            int? townId = (int?)await getTownIdCmd.ExecuteScalarAsync();

            if (townId == null)
            {
                SqlCommand addTown =
                    new SqlCommand(SqlQueries.AddTown, connection, sqlTransaction);
                addTown.Parameters.AddWithValue("@townName", townName);

                await addTown.ExecuteNonQueryAsync();

                townId = (int?)await getTownIdCmd.ExecuteScalarAsync();

                Console.WriteLine($"Town {townName} was added to the database.");
            }

            return townId;
        }
        private static async Task<int?> GetVillainId(string villainName, SqlConnection connection, SqlTransaction sqlTransaction)
        {
            SqlCommand getVillainId =
                new SqlCommand(SqlQueries.GetVillainId, connection, sqlTransaction);
            getVillainId.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getVillainId.ExecuteScalarAsync();

            if (villainId == null)
            {
                SqlCommand addVillain =
                    new SqlCommand(SqlQueries.AddVillain, connection, sqlTransaction);
                addVillain.Parameters.AddWithValue("@villainName", villainName);

                await addVillain.ExecuteNonQueryAsync();

                villainId = (int?)await getVillainId.ExecuteScalarAsync();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }


    }
}