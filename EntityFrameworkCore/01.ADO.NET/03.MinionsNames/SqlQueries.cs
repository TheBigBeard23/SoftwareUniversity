﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinionsNames
{
    public static class SqlQueries
    {
        public const string GetVillainById = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string GetMinionsByVillainId = @"
            SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                   m.Name, 
                   m.Age
              FROM MinionsVillains AS mv
              JOIN Minions As m ON mv.MinionId = m.Id
             WHERE mv.VillainId = @Id
          ORDER BY m.Name
        ";
    }
}
