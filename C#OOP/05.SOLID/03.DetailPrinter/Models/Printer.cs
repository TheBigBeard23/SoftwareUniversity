using DetailPrinter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DetailPrinter
{
    public class Printer
    {
        private List<IPrinter> printers;

        public Printer()
        {
            printers = new List<IPrinter>();

            var types = Assembly.GetExecutingAssembly()
                 .GetTypes()
                 .Where(t => typeof(IPrinter).IsAssignableFrom(t) &&
                 typeof(IPrinter) != t)
                 .ToList();

            foreach (var type in types)
            {
                printers.Add((IPrinter)Activator.CreateInstance(type));
            }
        }

        public void PrintDetails(IEmployee employee)
        {
            var printer = printers.First(d => d.IsMatch(employee));
            printer.PrintDetails(employee);
        }
    }
}
