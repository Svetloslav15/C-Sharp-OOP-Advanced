namespace Last_Army
{
    public class RPG : Ammunition
    {
        public const double Weight = 17.1;
        public double WearLevel { get; private set;}

        public RPG(string name)
            : base(name, Weight)
        {
            this.WearLevel = Weight * 100;
        }
    }
}