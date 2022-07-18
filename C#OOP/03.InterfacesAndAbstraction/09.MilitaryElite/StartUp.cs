using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Model;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();

                string type = data[0];

                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(data[4]);

                    soldiersById[id] = new Private(id, firstName, lastName, salary);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(data[4]);

                    ILieutenantGeneral lieutenantGeneral =
                        new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];

                        if (soldiersById.ContainsKey(privateId))
                        {
                            lieutenantGeneral.AddPrivate((IPrivate)soldiersById[privateId]);
                        }
                    }
                    soldiersById[id] = lieutenantGeneral;

                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(data[4]);

                    bool isCorpsValid = Enum.TryParse(data[5], out Corps corps);

                    if (isCorpsValid)
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string part = data[i];
                            int hoursWorked = int.Parse(data[i + 1]);

                            IRepair repair = new Repair(part, hoursWorked);

                            engineer.AddRepair(repair);
                        }
                        soldiersById[id] = engineer;
                    }

                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(data[4]);
                    bool isCorpsValid = Enum.TryParse(data[5], out Corps corps);

                    if (isCorpsValid)
                    {
                        ICommando comando = new Commando(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string codeName = data[i];
                            if (Enum.TryParse(data[i + 1], out MissionState missionState))
                            {
                                IMission mission = new Mission(codeName, missionState);
                                comando.AddMission(mission);
                            }
                        } 
                        soldiersById[id] = comando;
                    }

                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(data[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (var soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
            
        }
    }
}
