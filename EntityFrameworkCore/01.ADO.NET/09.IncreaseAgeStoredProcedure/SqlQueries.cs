using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IncreaseAgeStoredProcedure
{
    public static class SqlQueries
    {
        public const string GetMinion = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

        public const string IncreaseMinionAge = "EXEC usp_GetOlder @Id";
    }
}
