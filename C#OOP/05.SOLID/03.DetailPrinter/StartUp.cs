using System;

namespace DetailPrinter
{
    class StartUp
    {
        static void Main()
        {
            Manager manager = new Manager("Ivan",
                              new string[] { "reports", "operation" });
            Employee employee = new Employee("Pesho");
            Printer printer = new Printer();

            printer.PrintDetails(manager);
            printer.PrintDetails(employee);
        }
    }
}
