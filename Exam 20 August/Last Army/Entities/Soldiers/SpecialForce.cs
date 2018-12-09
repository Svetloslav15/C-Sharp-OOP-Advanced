using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const int SpecialForceRegenerateValue = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
    public override void Regenerate() => this.Endurance += this.Age + SpecialForceRegenerateValue;
    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;
    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed.AsReadOnly();
}