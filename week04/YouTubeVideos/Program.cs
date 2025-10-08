using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Building a Web Developer Portfolio from Scratch", "Mosa Molapo", 540);
        v1.AddComment(new Comment("Tumi", "This helped me organize my own portfolio—thank you!"));
        v1.AddComment(new Comment("Lerato", "I love how clean your design looks."));
        v1.AddComment(new Comment("Thabo", "The section about projects was really helpful."));
        videos.Add(v1);

        Video v2 = new Video("HTML & CSS for Beginners: Build Your First Website", "Mosa Molapo", 600);
        v2.AddComment(new Comment("Kamohelo", "You explain flexbox better than my instructor!"));
        v2.AddComment(new Comment("Boitumelo", "Can you make a video on responsive layouts next?"));
        v2.AddComment(new Comment("Neo", "I finally understand how to link my CSS file."));
        videos.Add(v2);

        Video v3 = new Video("Creating an Interactive To-Do List App with JavaScript", "Mosa Molapo", 480);
        v3.AddComment(new Comment("Palesa", "I followed along and my app actually works!"));
        v3.AddComment(new Comment("Sihle", "This tutorial made JS less intimidating."));
        v3.AddComment(new Comment("Lebo", "Please do a part 2 with localStorage!"));
        videos.Add(v3);

        Video v4 = new Video("How I Started My Web Development Journey", "Mosa Molapo", 420);
        v4.AddComment(new Comment("Karabo", "So inspiring! I’m just starting out too."));
        v4.AddComment(new Comment("Nathi", "I love your honesty about learning challenges."));
        v4.AddComment(new Comment("Thato", "Subscribed! Can’t wait for more dev content."));
        videos.Add(v4);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }

        Console.WriteLine("\nProgram complete.");
    }
}
