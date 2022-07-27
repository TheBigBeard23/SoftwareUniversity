using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Exceptions
{
    public class FuelOutOfTankException : Exception
    {
        public FuelOutOfTankException(string message)
            : base(message)
        {
        }
    }
}
