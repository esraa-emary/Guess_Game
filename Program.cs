using System;
using System.Collections.Generic;
using System.Numerics;
using Guess_Game;
using static System.Formats.Asn1.AsnWriter;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to my guess game application");
        Console.WriteLine("The game description is to try to guess a number based on difficulty and you have 3 tries to guess to get 1 point or lose.\n");
        Game game = new Game();
        while (true)
        {
            Console.Write("Please enter your name:");               // get player data
            string name = Console.ReadLine();
            int score = 0;

            while (true)
            {
                Console.Write("\nWhich difficulty uou preferre? \n[1] Easy (1:20).\n[2] Medium (1:50).\n[3] Hard (1:100).\nChoice: ");    // get difficulty
                int difficulty = int.Parse(Console.ReadLine());

                switch (difficulty)
                {
                    case 1:
                        score = game.play(20);
                        break;
                    case 2:
                        score = game.play(50);
                        break;
                    case 3:
                        score = game.play(100);
                        break;
                }

                if (!game.scores.ContainsKey(name)) game.scores.Add(name, score);       // update score
                else game.scores[name] += score;
                if (game.scores[name] >= game.mx)
                {
                    game.mx = game.scores[name];
                    game.name = name;
                }
                Console.WriteLine($"\nMax score is {game.mx} by {game.name}.");
                    
                Console.Write("\nDo you want to continue? \n[1] Yes.\n[2] No.\nChoice: ");    // check continue or not
                int cont = int.Parse(Console.ReadLine());
                if (cont == 2) break;
            }

            Console.Write("\nAnyone else want to play? \n[1] Yes.\n[2] No.\nChoice: ");    // check continue or not
            int repeat = int.Parse(Console.ReadLine());
            if (repeat == 2) break;
        }
        Console.Write("\nThanks for playing!");
    }
}
