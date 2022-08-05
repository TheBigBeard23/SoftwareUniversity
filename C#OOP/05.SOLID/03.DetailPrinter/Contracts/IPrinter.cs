using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Contracts
{
    public interface IPrinter
    {
        void PrintDetails(IEmployee employee);
        bool IsMatch(IEmployee printer);
    }
}
