namespace Vehicles
{
    public class Truck : IVehicle
    {
        private const double ACModificator = 1.6;
        private const double tankAmortization = 0.95;
        private double fuelQuantity;
        public Truck(double fualQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fualQuantity;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * (ACModificator + FuelConsumption);

            if (FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException("Truck needs refueling");
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }

        public void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            else if (this.fuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                this.fuelQuantity += amount * tankAmortization;
            }
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}
