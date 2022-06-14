using System;
using System.Collections.Generic;
using System.Text;

namespace _05.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Color = "n/a";
        }
        public Car(string model, Engine engine, int weight)
            :this(model,engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            :this(model,engine)
        {
            Color = color;
        }
        public Car(string model,Engine engine,int weight,string color)
            :this(model,engine)
        {
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {CheckValue(Engine.Displacement)}");
            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine($"  Weight: {CheckValue(Weight)}");
            sb.AppendLine($"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }

        private string CheckValue(int value)
        {
            if (value == 0)
            {
                return "n/a";
            }
            return value.ToString();
        }
    }
}
