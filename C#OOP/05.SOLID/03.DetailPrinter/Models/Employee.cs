using DetailPrinter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual string Print()
        {
            return Name;
        }
    }
}
