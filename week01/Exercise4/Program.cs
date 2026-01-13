using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World! This is the Exercise4 Project.");


        List<int> numbers = new List<int>();
        int promptInt;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        do
        {
            Console.Write("Enter number: ");
            string prompt = Console.ReadLine();
            promptInt = int.Parse(prompt);
            if (promptInt != 0)
            {
                numbers.Add(promptInt);
            }

        } while (promptInt != 0);

        int largestNumber = numbers[0];
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
            if (number > largestNumber)
                largestNumber = number;
        }

        int count = numbers.Count();

        double average = (double)sum / count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");

    }
}