using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Exceptions
{
    public class NegativeFuelException : Exception
    {
        private const string ExceptionMessage = "Fuel must be a positive number";
        public NegativeFuelException()
            : base(ExceptionMessage)
        {
        }
    }
}
