namespace Vehicles
{
    public class Bus : IVehicle
    {
        private const double ACModificator = 1.4;
        private double fuelQuantity;
        public Bus(double fuealQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuealQuantity;
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
            double neededFuel = distance * (this.FuelConsumption + ACModificator);

            if (FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
        public void DriveEmpty(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException("Bus needs refueling");
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
        public void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            else if (fuelQuantity + amount > this.TankCapacity)
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
            return $"Bus: {FuelQuantity:f2}";
        }
    }
}
