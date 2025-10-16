namespace ExerciseTracking
{
    class Running : Activity
    {
        private double _distance;

        public Running(string date, double minutes, double distance) : base(date, minutes)
        {
            _distance = distance; // km
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (_distance / Minutes) * 60;
        public override double GetPace() => Minutes / _distance;
    }
}
