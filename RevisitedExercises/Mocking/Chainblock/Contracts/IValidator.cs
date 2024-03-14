using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Contracts
{
    public interface IValidator
    {
        bool ValidateNotEmpty(IEnumerable<ITransaction> transactions, string message);
    }
}
