
using VehiclesExtension.Contracts;
using VehiclesExtension.Exceptions;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const double AirConditionerConsumption = 1.4;
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;

        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;

            }
        }
        public double FuelConsumption
        {
            get;
            protected set;
        }
        public int TankCapacity
        {
            get;
            private set;
        }

        public string Drive(double distance)
        {
            bool canDrive = FuelQuantity >= FuelConsumption * distance;

            if (canDrive)
            {
                FuelQuantity -= FuelConsumption * distance;
                return $"{GetType().Name} travelled {distance} km";
            }

            throw new LowFuelException($"{GetType().Name} needs refueling");
        }
        public virtual string DriveEmpty(double distance)
        {
            return Drive(distance);
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new NegativeFuelException();
            }
            if (fuel + fuelQuantity > TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit { fuel } fuel in the tank");
            }
            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
