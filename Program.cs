using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Generator!");
            Console.Write("Enter the desired length of the password: ");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Select the complexity level:");
            Console.WriteLine("1 - Simple (lowercase letters)");
            Console.WriteLine("2 - Moderate (lowercase and uppercase letters)");
            Console.WriteLine("3 - Complex (lowercase, uppercase letters, and digits)");
            Console.WriteLine("4 - Very Complex (lowercase, uppercase letters, digits, and special characters)");
            int complexity = int.Parse(Console.ReadLine());

            string password = GeneratePassword(length, complexity);
            Console.WriteLine($"Generated Password: {password}");
        }

        static string GeneratePassword(int length, int complexity)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()_-+=<>?";

            StringBuilder characterSet = new StringBuilder(lower);
            if (complexity >= 2) characterSet.Append(upper);
            if (complexity >= 3) characterSet.Append(digits);
            if (complexity == 4) characterSet.Append(special);

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            return password.ToString();
        }
    }
}
