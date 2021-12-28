using System;
using System.Text;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            double musala = 0;
            double montBlanc = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;
            double peopleCount = 0;
            for (int i = 0; i < groupsCount; i++)
            {
                int groupPeopleCount = int.Parse(Console.ReadLine());
                peopleCount += groupPeopleCount;

                if (groupPeopleCount <= 5)
                {
                    musala += groupPeopleCount;
                }
                else if(groupPeopleCount >= 6 && groupPeopleCount <= 12)
                {
                    montBlanc += groupPeopleCount;
                }
                else if (groupPeopleCount >= 13 && groupPeopleCount <= 25)
                {
                    kilimanjaro += groupPeopleCount;
                }
                else if (groupPeopleCount >= 26 && groupPeopleCount <= 40)
                {
                    k2 += groupPeopleCount;
                }
                else if (groupPeopleCount >= 41)
                {
                    everest += groupPeopleCount;
                }
            }

            musala = musala / peopleCount * 100;
            montBlanc = montBlanc / peopleCount * 100;
            kilimanjaro = kilimanjaro / peopleCount * 100;
            k2 = k2 / peopleCount * 100;
            everest = everest / peopleCount * 100;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{musala:f2}%");
            sb.AppendLine($"{montBlanc:f2}%");
            sb.AppendLine($"{kilimanjaro:f2}%");
            sb.AppendLine($"{k2:f2}%");
            sb.AppendLine($"{everest:f2}%");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
