using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random = new Random();

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times when you have shown strength and resilience."
        )
    {
        _prompts = new List<string>
        {
            "Think of a time when you helped someone.",
            "Think of a time when you did something difficult.",
            "Think of a time when you showed courage.",
            "Think of a time when you stood up for someone."
        };

        _questions = new List<string>
        {
            "Why was this meaningful?",
            "How did you feel?",
            "What did you learn?",
            "How can you use this experience again?",
            "What made this possible?"
        };
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }
}
