using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
  Glow Up Quest 🌸 by Mosa Molapo
  Personalized Eternal Quest Program

  Theme: Self-growth, spirituality, and positivity.
  Goals: Daily Scripture Study, Journaling, and Gratitude Practice.
  Rewards: Earn “Glow Points” ✨ and level up your Glow Level every 1000 points.
  Fun Additions: Cute sound effects and motivational messages when you level up!

  Features:
  - Three built-in goals with option to add more.
  - Inheritance and polymorphism through different goal types.
  - Save and load progress with glow points.
  - Console-based gamified experience with motivational messages.
*/

namespace GlowUpQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager();
            manager.LoadFromFile("glowup_goals.txt");

            Console.WriteLine("💖 Welcome to your Glow Up Quest, Mosa! 💖\n");
            Console.WriteLine("Let’s build your light, one goal at a time. 🌟\n");

            // Pre-added goals (only added if no file exists)
            if (manager.GoalsCount == 0)
            {
                manager.AddGoal(new EternalGoal("Daily Scripture Study", 100));
                manager.AddGoal(new EternalGoal("Journaling", 50));
                manager.AddGoal(new EternalGoal("Gratitude Practice", 75));
                Console.WriteLine("✨ Starter goals added to your Glow Up Quest! ✨\n");
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Glow Points: {manager.Score}  | Glow Level: {manager.Level}  | Points to next level: {manager.PointsToNextLevel}\n");
                Console.WriteLine("Menu:\n1. Add new goal\n2. List goals\n3. Record accomplishment\n4. Save progress\n5. Load progress\n6. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateGoal(manager); break;
                    case "2": manager.ListGoals(); break;
                    case "3": RecordEvent(manager); break;
                    case "4": manager.SaveToFile("glowup_goals.txt"); Console.WriteLine("💾 Progress saved successfully!\n"); break;
                    case "5": manager.LoadFromFile("glowup_goals.txt"); Console.WriteLine("📂 Progress loaded!\n"); break;
                    case "6":
                        manager.SaveToFile("glowup_goals.txt");
                        Console.WriteLine("🌷 Saved and exiting your Glow Up Quest. Keep shining, Grace! 🌷");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("⚠️ Invalid choice, try again!\n");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Choose goal type:\n1. Simple Goal (one-time)\n2. Eternal Goal (repeating)\n3. Checklist Goal");
            Console.Write("Type: ");
            var t = Console.ReadLine();

            Console.Write("Enter a description for your new goal: ");
            var name = Console.ReadLine();

            Console.Write("Glow Points earned per completion: ");
            int.TryParse(Console.ReadLine(), out int points);

            switch (t)
            {
                case "1": manager.AddGoal(new SimpleGoal(name, points)); break;
                case "2": manager.AddGoal(new EternalGoal(name, points)); break;
                case "3":
                    Console.Write("How many times must this goal be done to complete it? ");
                    int.TryParse(Console.ReadLine(), out int req);
                    Console.Write("Bonus Glow Points when finished: ");
                    int.TryParse(Console.ReadLine(), out int bonus);
                    manager.AddGoal(new ChecklistGoal(name, points, req, bonus));
                    break;
                default: Console.WriteLine("Invalid goal type.\n"); break;
            }

            Console.WriteLine("🌸 Goal added! Keep glowing. 🌸\n");
        }

        static void RecordEvent(GoalManager manager)
        {
            if (manager.GoalsCount == 0)
            {
                Console.WriteLine("You have no goals yet! Add some first. 🌱\n");
                return;
            }

            manager.ListGoals(true);
            Console.Write("Enter the number of the goal you completed: ");
            if (int.TryParse(Console.ReadLine(), out int idx))
            {
                if (idx >= 1 && idx <= manager.GoalsCount)
                {
                    var gained = manager.RecordEvent(idx - 1);
                    if (gained > 0)
                    {
                        Console.WriteLine($"✨ You gained {gained} Glow Points! ✨\n");
                        if (manager.JustLeveledUp)
                        {
                            Console.WriteLine("🎉💫 LEVEL UP! Your inner light shines even brighter! 💫🎉\n");
                        }
                    }
                }
                else Console.WriteLine("Invalid number.\n");
            }
        }
    }

    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        private int _lastLevel = 0;

        public int Score => _score;
        public int GoalsCount => _goals.Count;
        public int Level => _score / 1000;
        public int PointsToNextLevel => 1000 - (_score % 1000);
        public bool JustLeveledUp => Level > _lastLevel;

        public void AddGoal(Goal g) => _goals.Add(g);

        public void ListGoals(bool showIndex = false)
        {
            Console.WriteLine("🌼 Your Current Goals 🌼");
            if (_goals.Count == 0)
            {
                Console.WriteLine("(No goals yet — time to start glowing!)\n");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                var g = _goals[i];
                string prefix = showIndex ? ($"{i + 1}. ") : "";
                Console.WriteLine(prefix + g.DisplayString());
            }
            Console.WriteLine();
        }

        public int RecordEvent(int index)
        {
            _lastLevel = Level;
            int gained = _goals[index].RecordEvent();
            _score += gained;
            return gained;
        }

        public void SaveToFile(string path)
        {
            using (var w = new StreamWriter(path))
            {
                w.WriteLine(_score);
                foreach (var g in _goals)
                {
                    w.WriteLine(g.ToFileString());
                }
            }
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;
            var lines = File.ReadAllLines(path);
            if (lines.Length == 0) return;
            _goals.Clear();
            int.TryParse(lines[0], out _score);
            for (int i = 1; i < lines.Length; i++)
            {
                var g = Goal.FromFileString(lines[i]);
                if (g != null) _goals.Add(g);
            }
        }
    }

    public abstract class Goal
    {
        public string Name { get; protected set; }
        public int Points { get; protected set; }
        public bool Completed { get; protected set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            Completed = false;
        }

        public abstract int RecordEvent();
        public abstract string DisplayString();
        public abstract string ToFileString();

        public static Goal FromFileString(string line)
        {
            var p = line.Split('|');
            if (p.Length < 3) return null;

            string type = p[0];
            string name = p[1];
            int.TryParse(p[2], out int points);

            switch (type)
            {
                case "Simple": return new SimpleGoal(name, points);
                case "Eternal": return new EternalGoal(name, points);
                case "Checklist":
                    int.TryParse(p[3], out int req);
                    int.TryParse(p[4], out int bonus);
                    int.TryParse(p[5], out int curr);
                    var c = new ChecklistGoal(name, points, req, bonus);
                    c.SetCurrent(curr);
                    return c;
                default: return null;
            }
        }
    }

    public class SimpleGoal : Goal
    {
        private bool _done;
        public SimpleGoal(string name, int points) : base(name, points) { }
        public override int RecordEvent()
        {
            if (_done) return 0;
            _done = true;
            Completed = true;
            return Points;
        }
        public override string DisplayString() => $"[{(_done ? 'X' : ' ')}] Simple: {Name} (+{Points} Glow Points)";
        public override string ToFileString() => $"Simple|{Name}|{Points}|{_done}";
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }
        public override int RecordEvent() => Points;
        public override string DisplayString() => $"[∞] Eternal: {Name} (+{Points} Glow Points each time)";
        public override string ToFileString() => $"Eternal|{Name}|{Points}";
    }

    public class ChecklistGoal : Goal
    {
        private int _required;
        private int _bonus;
        private int _current;

        public ChecklistGoal(string name, int points, int required, int bonus) : base(name, points)
        {
            _required = required;
            _bonus = bonus;
            _current = 0;
        }

        public override int RecordEvent()
        {
            if (_current >= _required) return 0;
            _current++;
            if (_current >= _required)
            {
                Completed = true;
                return Points + _bonus;
            }
            return Points;
        }

        public void SetCurrent(int value) => _current = value;
        public override string DisplayString() => $"[{(Completed ? 'X' : ' ')}] Checklist: {Name} ({_current}/{_required} done, +{Points} Glow Points, +{_bonus} bonus)";
        public override string ToFileString() => $"Checklist|{Name}|{Points}|{_required}|{_bonus}|{_current}";
    }
}
