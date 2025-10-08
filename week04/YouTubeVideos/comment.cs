using System;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"  - {Name}: {Text}");
    }
}
