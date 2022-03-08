using System;

namespace _06.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (var username in usernames)
            {
                if (CheckUsername(username))
                {
                    Console.WriteLine(username);
                }
            }
        }
        static bool CheckUsername(string username)
        {
            if (username.Length < 3 ||
                username.Length > 16)
            {
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                char crnChar = username[i];

                if (!char.IsDigit(crnChar)  &&
                    !char.IsLetter(crnChar) &&
                    crnChar != '_'          && 
                    crnChar != '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
