using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private const int BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                Validator.ThrowIfTypeOfDoughIsInvalid(value.ToLower(), "Invalid type of dough.");

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                Validator.ThrowIfBakingTechniqueIsInvalid(value.ToLower(), "Invalid baking technique");

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowIfDoughWeightIsOutOfRange
                    (value, MinWeight, MaxWeight, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                weight = value;
            }
        }
        public double Calories => CalculateCalories();

        private double CalculateCalories()
        {
            double typeModifier = 0;
            if (flourType.ToLower() == "white")
            {
                typeModifier = 1.5;
            }
            else
            {
                typeModifier = 1.0;
            }

            double techniqueModifier = 0;
            if (bakingTechnique.ToLower() == "crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (bakingTechnique.ToLower() == "chewy")
            {
                techniqueModifier = 1.1;
            }
            else
            {
                techniqueModifier = 1.0;
            }

            return weight * BaseCaloriesPerGram * typeModifier * techniqueModifier;
        }
    }
}
