using System;

namespace _11.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string newText = string.Empty;

            while (text.Length>0)
            {
                char crnChar = text[0];
                newText += crnChar;
                text = text.Remove(0, 1);

                while (crnChar == text[0])
                {
                    text = text.Remove(0, 1);

                    if (text.Length == 0)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(newText);
        }
    }
}
