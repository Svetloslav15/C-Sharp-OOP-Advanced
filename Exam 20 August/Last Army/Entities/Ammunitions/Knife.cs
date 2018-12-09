namespace Last_Army
{
    public class Knife : Ammunition
    {
        public const double Weight = 0.4;
        public double WearLevel { get; private set; }

        public Knife(string name)
            : base (name, Weight)
        {
            this.WearLevel = Weight * 100;
        }
    }
}