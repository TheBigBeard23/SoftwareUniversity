using DetailPrinter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Printers
{
    class ManagerPrinter : IPrinter

    {
        public bool IsMatch(IEmployee employee)
        {
            return employee is Manager;
        }

        public void PrintDetails(IEmployee employee)
        {
            Console.WriteLine(employee.Print());
        }
    }
}
