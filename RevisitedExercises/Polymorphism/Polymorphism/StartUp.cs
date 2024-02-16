namespace Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split();

            Dictionary<string, IVehicle> vehicles = new Dictionary<string, IVehicle>();

            vehicles["Car"] = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine()
                .Split();

            vehicles["Truck"] = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine()
                .Split();

            vehicles["Bus"] = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0].ToLower();
                string type = input[1];
                double amount = double.Parse(input[2]);

                try
                {
                    switch (command)
                    {
                        case "drive":
                            vehicles[type].Drive(amount);
                            break;

                        case "refuel":
                            vehicles[type].Refuel(amount);
                            break;

                        case "driveempty":
                            ((Bus)vehicles[type]).DriveEmpty(amount);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in vehicles.Values)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}