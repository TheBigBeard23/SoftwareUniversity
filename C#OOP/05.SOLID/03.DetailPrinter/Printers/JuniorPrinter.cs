using DetailPrinter.Contracts;
using DetailPrinter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Printers
{
    public class JuniorPrinter : IPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            return employee is Junior;
        }

        public void PrintDetails(IEmployee employee)
        {
            Console.WriteLine(employee.Print());
        }
    }
}
