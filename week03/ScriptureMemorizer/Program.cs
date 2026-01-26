using System;

using System;

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
            string reference = parts[0].Trim();
            string text = parts[1].Trim();
            books[currentBook].Add(new Scripture(reference, text));
        }

        Console.WriteLine("Available books:");
        foreach (var book in books.Keys)
            Console.WriteLine("- " + book);

        Console.Write("\nType the book you want to memorize: ");
        string chosenBook = Console.ReadLine().Trim();

        if (!books.ContainsKey(chosenBook) || books[chosenBook].Count == 0)
        {
            Console.WriteLine("Book not found or empty.");
            return;
        }

        Random rnd = new Random();
        Scripture scripture = books[chosenBook][rnd.Next(books[chosenBook].Count)];

        while (!scripture.AllHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press ENTER to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;
            scripture.HideRandomWords();
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("All words are hidden. Program ends.");
    }
}
