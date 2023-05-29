using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.InitialSetup
{
    public static class Configuration
    {
        public static string GetConnectionString(string database)
        {
            if (database != "")
            {
                return @$"Server=.;User Id=sa;Password=*;Database={database};TrustServerCertificate=True";
            }
            else
            {
                return @"Server=.;User Id=sa;Password=*;TrustServerCertificate=True";
            }
        }
    }
}
