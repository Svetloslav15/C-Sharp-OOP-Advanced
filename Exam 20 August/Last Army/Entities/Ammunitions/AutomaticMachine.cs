public class AutomaticMachine : Ammunition
{
    public const double Weight = 6.3;
    public double WearLevel { get; private set; }

    public AutomaticMachine(string name)
        : base(name, Weight)
    {
        this.WearLevel = Weight * 100;
    }
}