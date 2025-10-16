using System;

namespace ExerciseTracking
{
    abstract class Activity
    {
        private string _date;
        private double _minutes;

        public Activity(string date, double minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public string Date { get { return _date; } }
        public double Minutes { get { return _minutes; } }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{_date} - Mosa Molapo did {this.GetType().Name} for {_minutes} minutes: " +
                   $"Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
        }
    }
}
