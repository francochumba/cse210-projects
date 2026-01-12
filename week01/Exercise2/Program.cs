using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string gradeMessage = "";

        if (grade >= 70)
        {
            gradeMessage = "You passed, congratulations.";
        }
        else
        {
            gradeMessage = "You did not pass, keep trying.";
        }
        Console.WriteLine($"Your Grade is {letter}. {gradeMessage}");
    }
}