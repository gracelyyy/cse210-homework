using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mosa Molapo Personalized Exercise Tracker");
            Console.WriteLine("----------------------------------------\n");

            List<Activity> activities = new List<Activity>()
            {
                new Running("16 Oct 2025", 30, 5.0),   // 5 km run
                new Cycling("16 Oct 2025", 45, 22.0),  // 22 kph cycling
                new Swimming("16 Oct 2025", 25, 40)    // 40 laps swimming
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }

            Console.WriteLine("\nKeep pushing, Mosa! 💪");
        }
    }
}
