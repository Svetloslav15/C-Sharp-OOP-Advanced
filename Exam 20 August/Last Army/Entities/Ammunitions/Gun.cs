namespace Last_Army
{
    public class Gun : Ammunition
    {
        public const double Weight = 1.4;
        public double WearLevel { get; private set; }

        public Gun(string name)
            : base(name, 1.4)
        {
            this.WearLevel = Weight * 100;
        }
    }
}