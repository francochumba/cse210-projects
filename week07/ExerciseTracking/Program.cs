/*
Exceeding Requirements:
I added a small improvement, the "Lap Swimming" so that the activities can customize the name shown in the summary,
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("03 Nov 2022", 45, 18.0));
        activities.Add(new Swimming("03 Nov 2022", 40, 30));

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
