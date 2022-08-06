using System;
using Recharge.Contracts;

namespace Recharge
{
    public abstract class Worker : IWorker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            Console.WriteLine($"{this.GetType().Name} working {hours} hours..");
            workingHours += hours;
        }

    }
}