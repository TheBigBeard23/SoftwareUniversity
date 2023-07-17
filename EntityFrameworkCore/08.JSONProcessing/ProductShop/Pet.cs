using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop
{
    public class Pet
    {
        public Pet()
        {
            Age = 3;
            Name = string.Empty;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
