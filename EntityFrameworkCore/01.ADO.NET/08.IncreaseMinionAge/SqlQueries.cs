﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IncreaseMinionAge
{
    public class SqlQueries
    {
        public const string IncreaseMinionAge = @"
         UPDATE Minions
            SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
          WHERE Id = @Id";

        public const string GetAllMinionsNameAndAge = @"SELECT Name, Age FROM Minions";
    }
}
