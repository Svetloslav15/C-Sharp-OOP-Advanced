namespace Last_Army
{
    public class Helmet : Ammunition
    {
        public const double Weight = 2.3;
        public double WearLevel { get; private set; }

        public Helmet(string name) 
            : base (name, Weight)
        {
            this.WearLevel = Weight * 100;
        }
    }
}