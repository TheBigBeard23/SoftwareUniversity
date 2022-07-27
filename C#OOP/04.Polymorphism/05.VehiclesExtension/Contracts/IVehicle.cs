

namespace VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public int TankCapacity { get; }
        string Drive(double distance);
        string DriveEmpty(double distance);
        void Refuel(double fuel);

    }
}
