namespace Recharge
{
    using Recharge.Contracts;
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) 
            : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }

    }
}
