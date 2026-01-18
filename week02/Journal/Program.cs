// Exceeding Requirements:
// I added an extra menu option that allows the user to clear all journal entries
// currently stored in memory. This gives the user an easy way to start a new
// journal without restarting the program. I also added a few extra prompts
// beyond the required minimum to give more variety.

using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        Console.WriteLine("");
        Console.WriteLine("¡Welcome to your Daily Journal!");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Write an entry to answer a question");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Clear the journal");
            Console.WriteLine("6. Quit");
            Console.WriteLine("");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string text = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = text;

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                journal.Clear();
                Console.WriteLine("Journal cleared succesfully.");
            }
            else if (choice == "6")
            {
                running = false;
            }
        }
    }
}