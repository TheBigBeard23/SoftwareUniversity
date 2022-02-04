using System;
using System.Linq;
using System.Text;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split().ToArray();

                switch (commands[0])
                {
                    case "exchange":

                        int index = int.Parse(commands[1]);

                        if (index >= 0 && index < array.Length)
                        {
                            array = Split(index, array);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "min":

                        string type = commands[1];

                        Console.WriteLine(GetIndexOfMinValue(type,array));

                        break;

                    case "max":

                        type = commands[1];

                        Console.WriteLine(GetIndexOfMaxValue(type,array));

                        break;

                    case "first":

                        type = commands[2];
                        int count = int.Parse(commands[1]);

                        if (count <= array.Length)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("[");
                            sb.Append(string.Join(", ", GetFirstNumbersByType(type, count, array)));
                            sb.Append("]");

                            Console.WriteLine(sb.ToString().TrimEnd());
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        
                        break;

                    case "last":

                        type = commands[2];
                        count = int.Parse(commands[1]);

                        if (count <= array.Length)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("[");
                            sb.Append(string.Join(", ", GetLastNumbersByType(type, count, array)));
                            sb.Append("]");

                            Console.WriteLine(sb.ToString().TrimEnd());
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }

                        break;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ",array)}]");
        }
        static int[] GetLastNumbersByType(string typeOfNumbers, int count, int[] array)
        {
            int[] sequance = new int[count];
            int counter = 0;

            if (typeOfNumbers == "odd")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 1 &&
                        counter < count)
                    {
                        sequance[counter] = array[i];
                        counter++;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0 &&
                        counter < count)
                    {
                        sequance[counter] = array[i];
                        counter++;
                    }
                }
            }

            int[] newSequance = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                newSequance[i] = sequance[i];
            }

            return newSequance.Reverse().ToArray();

        }
        static int[] GetFirstNumbersByType(string typeOfNumbers,int count,int[] array)
        {
            int[] sequance = new int[count];
            int counter = 0;

            if (typeOfNumbers == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1 &&
                        counter < count)
                    {
                        sequance[counter] = array[i];
                        counter++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 &&
                        counter < count)
                    {
                        sequance[counter] = array[i];
                        counter++;
                    }
                }
            }

            int[] newSequance = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                newSequance[i] = sequance[i];
            }

            return newSequance;
            
        }
        static string GetIndexOfMaxValue(string numberType, int[] array)
        {
            int maxValue = int.MinValue;
            int index = -1;

            if (numberType == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1 &&
                        array[i] >= maxValue)
                    {
                        maxValue = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 &&
                        array[i] >= maxValue)
                    {
                        maxValue = array[i];
                        index = i;
                    }
                }
            }

            if (index > -1)
            {
                return index.ToString();
            }
            else
            {
                return "No matches";
            }
        }
        static string GetIndexOfMinValue(string numberType, int[] array)
        {
            int minValue = int.MaxValue;
            int index = -1;

            if (numberType == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 1 &&
                        array[i] <= minValue)
                    {
                        minValue = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 &&
                        array[i] <= minValue)
                    {
                        minValue = array[i];
                        index = i;
                    }
                }
            }

            if (index > -1)
            {
                return index.ToString();
            }
            else
            {
                return "No matches";
            }
        }
        static int[] Split(int index,int[] array)
        {
            int[] newArray = new int[array.Length];

            int counter = 0;

            for (int i = index + 1; i < array.Length; i++)
            {
                newArray[counter] = array[i];
                counter++;
            }
            for (int i = 0; i <= index; i++)
            {
                newArray[counter] = array[i];
                counter++;
            }

            return newArray;
        }
    }
}
