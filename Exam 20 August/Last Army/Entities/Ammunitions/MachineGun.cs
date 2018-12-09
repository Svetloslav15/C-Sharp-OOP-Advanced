namespace Last_Army
{
    public class MachineGun : Ammunition
    {
        public const double Weight = 10.6;
        public double WearLevel { get; private set; }

        public MachineGun(string name)
            : base(name, Weight)
        {
            this.WearLevel = Weight * 100;
        }
    }
}