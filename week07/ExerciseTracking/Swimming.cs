namespace ExerciseTracking
{
    class Swimming : Activity
    {
        private int _laps;

        public Swimming(string date, double minutes, int laps) : base(date, minutes)
        {
            _laps = laps; // 50m each lap
        }

        public override double GetDistance() => (_laps * 50) / 1000.0; // km
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();
    }
}
