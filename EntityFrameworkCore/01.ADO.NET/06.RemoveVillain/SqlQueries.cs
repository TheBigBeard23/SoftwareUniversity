using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveVillain
{
    public static class SqlQueries
    {
        public const string GetVillain = @"
        SELECT Name 
          FROM Villains 
         WHERE Id = @villainId";

        public const string DeleteMinionsFromVillain = @"
        DELETE FROM MinionsVillains 
         WHERE VillainId = @villainId";

        public const string DeleteVillain = @"
        DELETE FROM Villains
         WHERE Id = @villainId"; 
    }
}
