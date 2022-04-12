using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split()
                                                                  .Select(int.Parse)
                                                                  .ToArray());

            Queue<int> locks = new Queue<int>(Console.ReadLine().Split()
                                                                .Select(int.Parse)
                                                                .ToArray());

            int intelligence = int.Parse(Console.ReadLine());

            int bulletCounter = 0;
            int totalBulletPrice = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                bulletCounter++;
                totalBulletPrice += bulletPrice;

                int crnBullet = bullets.Pop();
                int crnLock = locks.Peek();

                if (crnBullet <= crnLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletCounter == gunBarrelSize &&
                    bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletCounter = 0;
                }

            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence-totalBulletPrice}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
