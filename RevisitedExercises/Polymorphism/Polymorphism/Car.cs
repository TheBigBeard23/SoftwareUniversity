namespace Vehicles
{
    public class Car : IVehicle
    {
        private const double ACModificator = 0.9;
        private double fuelQuantity;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
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
            double neededFuel = distance * (FuelConsumption + ACModificator);

            if (this.FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException("Car needs refueling");
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
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
                this.fuelQuantity += amount;
            }
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
