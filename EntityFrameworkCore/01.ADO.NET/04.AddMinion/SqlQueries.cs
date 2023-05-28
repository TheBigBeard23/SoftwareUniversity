using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _04.AddMinion
{
    public static class SqlQueries
    {
        public const string GetTownId = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string GetVillainId = @"SELECT Id FROM Villains WHERE Name = @Name";

        public static string GetMinionId = @"SELECT Id FROM Minions WHERE Name = @Name";

        public static string AddTown = @"INSERT INTO Towns(Name) VALUES(@townName)";

        public static string AddVillain = @"INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)";

        public static string AddMinion = @"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)";

        public static string AddMinionToVillain = @"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@minionId, @villainId)";
         
    }
}
