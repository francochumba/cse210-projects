using System;
using System.IO;

public class Reference
{
    public void Reader()
    {
        string[] lines = File.ReadAllLines("doctrinal_mastery.txt");

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (!line.Contains("|"))
            {
                Console.WriteLine("Section: " + line);
                continue;
            }

            string[] parts = line.Split(new char[] { "|" }, 2);
            string reference = parts[0];
            string text = parts[1];

            Console.WriteLine(reference + " -> " + text);
        }
    }
}
