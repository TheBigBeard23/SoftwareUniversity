using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
