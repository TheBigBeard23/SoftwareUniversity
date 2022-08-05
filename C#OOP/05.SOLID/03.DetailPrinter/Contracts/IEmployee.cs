using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Contracts
{
    public interface IEmployee
    {
        string Name { get;}

        string Print();
    }
}
