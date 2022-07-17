using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : Person
    {
        public Citizen(string name, int age, string id, string birthday)
            : base(name, age)
        {
            Id = id;
            Birthday = birthday;
        }
        public string Id { get; set; }
        public string Birthday { get; set; }

        public override void BuyFood()
        {
            Food += 10;
        }
    }
}
