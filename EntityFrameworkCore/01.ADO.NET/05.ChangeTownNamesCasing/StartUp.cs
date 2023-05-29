using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("MinionsDB"));
            await connection.OpenAsync();

            string country = Console.ReadLine();

            SqlCommand changeTownNamesCmd =
                new SqlCommand(SqlQueries.ChangeTownNamesByCountry, connection);
            changeTownNamesCmd.Parameters.AddWithValue("@countryName", country);

            int affectedRows = await changeTownNamesCmd.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");
                await PrintTowns(country, connection);
            }


        }

        private static async Task PrintTowns(string? country, SqlConnection connection)
        {
            SqlCommand getTownsCmd =
                new SqlCommand(SqlQueries.GetTownsByCountryName, connection);
            getTownsCmd.Parameters.AddWithValue("@countryName", country);

            SqlDataReader reader = await getTownsCmd.ExecuteReaderAsync();

            List<string> towns = new List<string>();

            while (reader.Read())
            {
                towns.Add((string)reader["Name"]);
            }

            Console.WriteLine($"[{String.Join(", ", towns)}]");
        }
    }
}