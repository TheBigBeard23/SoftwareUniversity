using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get;
            protected set;
        }
        public double FuelConsumption
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

            throw new FuelExceptions($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
