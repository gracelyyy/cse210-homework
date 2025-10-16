namespace ExerciseTracking
{
    class Cycling : Activity
    {
        private double _speed;

        public Cycling(string date, double minutes, double speed) : base(date, minutes)
        {
            _speed = speed; // kph
        }

        public override double GetDistance() => (_speed * Minutes) / 60;
        public override double GetSpeed() => _speed;
        public override double GetPace() => 60 / _speed;
    }
}
