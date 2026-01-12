using System;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        string lowerPlayAgain;
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        do
        {
            string guess;
            string playAgain;
            int randomNumber = Random.Shared.Next(10);
            int guessNumber;
            do
            {
                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                guessNumber = int.Parse(guess);
                if (guessNumber < randomNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessNumber > randomNumber)
                {
                    Console.WriteLine("Lower");
                }
            } while (guessNumber != randomNumber);

            Console.WriteLine($"You guessed it, the magic number is {randomNumber}");
            Console.WriteLine("Do you want to play Again? y/n");
            playAgain = Console.ReadLine();
            lowerPlayAgain = playAgain.ToLower();
        } while (lowerPlayAgain == "y");
    }
}