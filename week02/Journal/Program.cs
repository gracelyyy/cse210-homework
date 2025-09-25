using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        // ✨ Personalise this welcome message
        Console.WriteLine("Welcome to Mosa's Personal Journal App ✨");
        Console.WriteLine("A place to reflect, remember, and grow.\n");

        // ✨ Personalise this list of prompts
        List<string> prompts = new List<string>()
        {
            "What is something new I learned today?",
            "What was the best part of my day?",
            "How did I make someone else’s day better?",
            "What challenge did I face today, and how did I respond?",
            "What am I most grateful for today?",
            "If I could relive one moment from today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. Search entries by keyword"); // ✨ Bonus feature
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Random rand = new Random();
                    string prompt = prompts[rand.Next(prompts.Count)];
                    Console.WriteLine($"\n{prompt}");
                    string response = Console.ReadLine();

                    // ✨ Mood input (you could make this a fixed list if you want)
                    Console.Write("How was your mood today? (happy, sad, excited, etc.): ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save (default: MosaJournal.txt): ");
                    string saveFile = Console.ReadLine();

                    // ✨ Default save filename if user presses Enter
                    if (string.IsNullOrWhiteSpace(saveFile))
                        saveFile = "MyJournal.txt";

                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load (default: MyJournal.txt): ");
                    string loadFile = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(loadFile))
                        loadFile = "MyJournal.txt";

                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Goodbye! Keep journaling ✨");
                    return;

                case "6":
                    Console.Write("Enter a keyword to search: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
