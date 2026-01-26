/*Exceeding Requirements
- Menu allows the user to select a specific book (Pearl of Great Price, Old Testament, New Testament) or choose a random scripture from any book.
- Handles multi-word book names and en dash (–) verse ranges.
- Stores all scriptures in a dictionary by book, allowing multiple scriptures per book.
- Uses Random object parameterization in Scripture.HideRandomWords for better control and possible deterministic testing.
- Overloaded constructors in Reference.
- Addition of various methods for a cleaner code and more functionality.
- Open space for improvement such as better randomization (not repeating same hidden words), including other books (Book of Mormon, Doctrine and Covenants) and scripture selection.
- Other options that i could do in the future would be inverted functionality by hiding the whole verse and revealing words as the user inputs.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "doctrinal_mastery.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found: " + path);
            return;
        }

        Dictionary<string, List<Scripture>> books = new Dictionary<string, List<Scripture>>();
        string currentBook = "";

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (!line.Contains("|"))
            {
                currentBook = line.Trim();
                if (!books.ContainsKey(currentBook))
                    books[currentBook] = new List<Scripture>();
                continue;
            }

            string[] parts = line.Split('|', 2);
            string referenceStr = parts[0].Trim();
            string text = parts[1].Trim();

            Reference refObj = ParseReference(referenceStr);
            books[currentBook].Add(new Scripture(refObj, text));
        }

        Random rnd = new Random();

        while (true)
        {
            Console.WriteLine("¡Welcome to the Doctrine Mastery Memorizer!");
            Console.WriteLine("Please select a book to memorize, the scripture will be selected randomly:");
            Console.WriteLine("1 - Pearl of Great Price");
            Console.WriteLine("2 - Old Testament");
            Console.WriteLine("3 - New Testament");
            Console.WriteLine("4 - Random Book");
            Console.WriteLine("5 - Quit");

            string menuInput = Console.ReadLine().Trim();
            List<Scripture> selected = null;

            if (menuInput == "1")
            {
                if (books.ContainsKey("Pearl of Great Price"))
                    selected = books["Pearl of Great Price"];
            }
            else if (menuInput == "2")
            {
                if (books.ContainsKey("Old Testament"))
                    selected = books["Old Testament"];
            }
            else if (menuInput == "3")
            {
                if (books.ContainsKey("New Testament"))
                    selected = books["New Testament"];
            }
            else if (menuInput == "4")
            {
                selected = new List<Scripture>();
                foreach (var b in books.Values)
                    selected.AddRange(b);
            }
            else if (menuInput == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.\n");
                continue;
            }

            if (selected == null || selected.Count == 0)
            {
                Console.WriteLine("No scriptures found in the selected book.\n");
                continue;
            }

            Scripture scripture = selected[rnd.Next(selected.Count)];

            while (!scripture.AllHidden())
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("Press ENTER to hide words, or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit") break;
                scripture.HideRandomWords(3, rnd);
            }

            Console.Clear();
            scripture.Display();
            Console.WriteLine("All words are hidden. Press ENTER to return to menu.");
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine("Program ended successfully.");
    }

    static Reference ParseReference(string referenceStr)
    {
        referenceStr = referenceStr.Replace("–", "-");

        string[] parts = referenceStr.Split(' ');

        string chapterVerse = parts[^1];
        string book = string.Join(" ", parts, 0, parts.Length - 1);

        string[] cv = chapterVerse.Split(':');
        int chapter = int.Parse(cv[0]);

        if (cv[1].Contains("-"))
        {
            string[] verses = cv[1].Split('-');
            int verseStart = int.Parse(verses[0]);
            int verseEnd = int.Parse(verses[1]);
            return new Reference(book, chapter, verseStart, verseEnd);
        }
        else
        {
            int verse = int.Parse(cv[1]);
            return new Reference(book, chapter, verse);
        }
    }

}
