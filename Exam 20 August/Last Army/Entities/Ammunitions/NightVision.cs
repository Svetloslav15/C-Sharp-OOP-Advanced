namespace Last_Army
{
    public class NightVision : Ammunition
    {
        public const double Weight = 0.8;
        public double WearLevel { get; private set; }

        public NightVision(string name)
            : base (name, Weight)
        {
            this.WearLevel = Weight * 100;
        }
    }
}