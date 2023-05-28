using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.InitialSetup
{
    public static class Configuration
    {
        public static string ConnectionString(string database)
        {
            if (database != "")
            {
                return @$"Server=.;User Id=sa;Password=*;Database={database};MultipleActiveResultSets=True;TrustServerCertificate=True";
            }
            else
            {
                return @$"Server=.;User Id=sa;Password=*;MultipleActiveResultSets=True;TrustServerCertificate=True";
            }
        }
    }
}
