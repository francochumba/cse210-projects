using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private static Dictionary<string, int> _log = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

        if (!_log.ContainsKey(_name))
        {
            _log[_name] = 0;
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        _log[_name]++;

        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {_name} Activity for {_duration} seconds.");
        Console.WriteLine($"You have done this activity {_log[_name]} time(s).");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}
