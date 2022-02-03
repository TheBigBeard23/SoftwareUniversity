using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool validLength = CheckPasswordLength(password);
            bool validContent = CheckLettersAndDigits(password);
            bool validDigitsCount = CheckDigitsCount(password);

            if (!validLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!validContent)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!validDigitsCount)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if(validLength && 
               validContent &&
               validDigitsCount)
            {
                Console.WriteLine("Password is valid");
            }

        }
        static bool CheckPasswordLength(string password)
        {
            if (password.Length >= 6 &&
                password.Length <= 10)
            {
                return true;
            }

            return false;
        }
        static bool CheckLettersAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char currentSymbol = password[i];

                if(currentSymbol<48 ||
                   currentSymbol>57 && currentSymbol<65 ||
                   currentSymbol>90 && currentSymbol<97 ||
                   currentSymbol > 122)
                {
                    return false;
                }
            }

            return true;
        }
        static bool CheckDigitsCount(string password)
        {
            int count = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char currentSymbol = password[i];

                if(currentSymbol>47 && currentSymbol < 58)
                {
                    count++;
                }
            }

            if (count < 2)
            {
                return false;
            }

            return true;
        }

    }
}
