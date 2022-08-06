namespace Recharge
{
    using Recharge.Contracts;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            List<IWorker> workers = new List<IWorker>();

            Employee employee = new Employee("123");
            Robot robot = new Robot("143", 100);
            robot.Recharge();

            workers.Add(employee);
            workers.Add(robot);

            foreach (var worker in workers)
            {   
                worker.Work(10);
            }
        }
    }
}
