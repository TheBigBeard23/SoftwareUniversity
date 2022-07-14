using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Validator
    {
        public static void ThrowIfTypeOfDoughIsInvalid(string type, string exceptionMessage)
        {
            if (type != "white" &&
                type != "wholegrain")
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfBakingTechniqueIsInvalid(string type, string exceptionMessage)
        {
            if (type != "crispy" &&
                type != "chewy" &&
                type != "homemade")
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfDoughWeightIsOutOfRange
            (double weight, double min, double max, string exceptionMessage)
        {
            if (weight < min || weight > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfToppingTypeIsInvalid(string type, string exceptionMessage)
        {
            if (type != "meat" &&
                type != "veggies" &&
                type != "cheese" &&
                type != "sauce")
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfToppinghWeightIsOutOfRange
           (double weight, double min, double max, string exceptionMessage)
        {
            if (weight < min || weight > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfPizzaNameIsInvalid
            (string name, int min, int max, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(name)
                || name.Length > max
                || name.Length < min
                )
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfToppingsCountIsOutOfRange
            (int count, int min, int max, string exceptionMessage)
        {
            if (count < min || count > max)
            {
                throw new InvalidOperationException(exceptionMessage);
            }
        }
    }
}
