using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> clothes = new Queue<int>(Console.ReadLine().Split()
                                                                  .Select(int.Parse)
                                                                  .Reverse());
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;
            int crnClothes = 0;

            while (clothes.Count > 0)
            {
                crnClothes += clothes.Peek();

                if (crnClothes == capacity)
                {
                    counter++;
                    clothes.Dequeue();
                    crnClothes = 0;
                }
                else if (crnClothes > capacity)
                {
                    counter++;
                    crnClothes = 0;
                }
                else
                {
                    if (clothes.Count == 1)
                    {
                        counter++;
                    }
                    clothes.Dequeue();
                }

            }

            if (clothes.Count > 1)
            {
                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
