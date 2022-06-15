using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count => Cars.Count;

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                RemoveCar(number);
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (Cars.Where(x => x.RegistrationNumber == RegistrationNumber).Count() == 0)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(Cars.Where(x => x.RegistrationNumber == RegistrationNumber).FirstOrDefault());
                return $"Successfully removed {RegistrationNumber}";
            }
        }
        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
              return "Car with that registration number, already exists!";
            }
            else if (Cars.Count == Capacity)
            {
               return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

    }
}
