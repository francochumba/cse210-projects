using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you list positive things in your life."
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who have you helped recently?",
            "What makes you happy?",
            "What are you grateful for?"
        };
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("Start listing items:");
        ShowCountDown(3);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items.");

        DisplayEndingMessage();
    }
}
