using Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Models
{
    public static class Validator<T>
    {
        public static bool ValidateNotEmpty(IEnumerable<T> transactions, string message)
        {
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(message);
            }
            else
            {
                return true;
            }
        }
    }
}
