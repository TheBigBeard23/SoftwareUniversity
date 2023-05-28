using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinionNames
{
    public static class SqlQueries
    {
        public const string GetVillainNameById =
            @"SELECT Name From Villains WHERE Id = @Id";
        public const string GetAllMinionsByVillainId =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                     m.Name, 
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = 1
            ORDER BY m.Name";
    }
}
