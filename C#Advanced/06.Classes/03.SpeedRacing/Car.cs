using System;
using System.Collections.Generic;
using System.Text;

namespace _03.SpeedRacing
{
    public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            Kilometers = 0.0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double Kilometers { get; set; }

        public void Drive(double amountOfKm)
        {
            if (FuelAmount - amountOfKm * FuelConsumptionPerKm >= 0)
            {
                FuelAmount -= amountOfKm * FuelConsumptionPerKm;
                Kilometers += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
