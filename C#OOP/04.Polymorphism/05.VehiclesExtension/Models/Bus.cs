
using VehiclesExtension.Contracts;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + AirConditionerConsumption, tankCapacity)
        {
        }

        public override string DriveEmpty(double distance)
        {
            FuelConsumption -= AirConditionerConsumption;
            return base.Drive(distance);
        }
    }
}
