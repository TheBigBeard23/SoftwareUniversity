using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;
        private const double FuelWastage = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + AirConditionerConsumption)
        {

        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * FuelWastage;
        }
    }
}
