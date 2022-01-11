using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < count; i++)
            {
                string code = Console.ReadLine();
                int digitLength = code.Length;
                int digit = code[0] - '0';
                int offset = (digit - 2) * 3;


                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if(digit==8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}
