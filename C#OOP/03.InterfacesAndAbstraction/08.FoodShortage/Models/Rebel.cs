using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : Person
    {
        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            Group = group;
        }
        public string Group { get; set; }

        public override void BuyFood()
        {
            Food += 5;
        }
    }
}
