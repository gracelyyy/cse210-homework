using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        // for (int 1 = 5; i > 0; i--)
        // {
        //     Console.WriteLine(i);}
        //     Thread.Sleep(1000);
        //     Console.Write("\b")
        // }

        for (int i = 5; i > 0; i--)
        {
            Console.Write(".")
            Thread.Sleep(1000);
            //Console.WriteLine("\b")
        }

        // |/-\|/-\|
        List<string> animationsStrings = new List<string>();
        animationsStrings.Add("|");
        animationsStrings.Add("/");
        animationsStrings.Add("-");
        animationsStrings.Add("\");
        animationsStrings.Add("|");
        animationsStrings.Add("/");
        animationsStrings.Add("-");
        animationsStrings.Add("\");

        foreach (sting s in animationsStrings)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b")
       }

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(10);

        while (DateTime.Now < endTime)
        {
            string s = animationsStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i > animationsStrings.count)
            {
                i = 0;
            }
        }

        Console.WriteLine("Done.");
    }
}
