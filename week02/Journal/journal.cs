using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{

    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }


    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                
                sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        Entries.Clear(); 
        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    public void SearchEntries(string keyword)
    {
        var results = Entries.Where(e => e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine($"No entries found containing: {keyword}");
            return;
        }

        Console.WriteLine($"\nEntries containing \"{keyword}\":");
        foreach (var entry in results)
        {
            Console.WriteLine(entry);
        }
    }
}
