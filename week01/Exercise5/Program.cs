using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();

        string userName = PromptUserName();
        int favNumber = PromptUserNumber();
        int squareNumber = SquareNumber(favNumber);

        DisplayResult(userName, squareNumber);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favourite number: ");
        string favNumber = Console.ReadLine();
        int favNumberInt = int.Parse(favNumber);
        return favNumberInt;
    }

    static int SquareNumber(int favouriteNumber)
    {
        return favouriteNumber * favouriteNumber;
    }

    static void DisplayResult(string userName, int squareNumber)
    {
        Console.WriteLine($"Brother {userName}, the square of your number is {squareNumber}");
    }
}