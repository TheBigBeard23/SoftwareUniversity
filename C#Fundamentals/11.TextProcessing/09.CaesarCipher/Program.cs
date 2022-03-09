using System;

namespace _09.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string encryptedText = string.Empty;

            while (text.Length > 0)
            {
                encryptedText += (char)(text[0] + 3);
                text = text.Remove(0, 1);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
