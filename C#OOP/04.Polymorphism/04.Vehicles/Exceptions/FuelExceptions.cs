using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Exceptions
{
    public class FuelExceptions : Exception
    {
        public FuelExceptions(string message)
            : base(message)
        {
        }
 
    }
}
