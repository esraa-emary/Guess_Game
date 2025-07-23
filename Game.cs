using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Game
{
    internal class Game
    {
        public Dictionary<string, int> scores = new Dictionary<string, int>();
        public int mx = 0;
        public string name = "";

        public int play(int num)
        {
            int score = 0, tries = 3;
            Random random = new Random();
            int real = random.Next(1, num + 1);

            Console.WriteLine("\nYou have 3 tries to guess the nymber or you will lose!");

            while (tries > 0)
            {
                Console.Write("Enter a number: ");
                int number = int.Parse(Console.ReadLine());

                if (number > real) Console.WriteLine("\nThe real number is smaller.");
                else if (number < real) Console.WriteLine("\nThe real number is bigger.");
                else
                {
                    Console.WriteLine("\nYou got it :)\n");
                    score = 1;
                    break;
                }
                tries--;
            }
            Console.WriteLine($"\nThe real number is {real}");
            return score;
        }
    }
}
