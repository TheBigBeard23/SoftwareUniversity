using DetailPrinter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Printers
{
    class EmployeePrinter : IPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            return employee is Employee;
        }

        public void PrintDetails(IEmployee employee)
        {
            Console.WriteLine(employee.Print());
        }
    }
}
