using System.Collections.Generic;
using System.Linq;
using System;

public abstract class Soldier : ISoldier
{
    private double endurance;
    private string name;
    private int age;
    private double experience;
    private const int MaxEndurance = 100;
    private const int SoldierRegenerateValue = 10;

    public double Experience
    {
        get => this.experience;
        set { this.experience = value; }
    }

    public double Endurance
    {
        get => this.endurance;
        set { this.endurance = value; }
    }
    public int Age
    {
        get => this.age;
        set { age = value; }
    }
    public string Name
    {
        get => this.name;
        set { name = value; }
    }
    public Soldier(string name, int age, double endurance, double experience)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
    }
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual double OverallSkill => throw new System.NotImplementedException();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public virtual void Regenerate() => this.Endurance += this.Age + SoldierRegenerateValue;

    public void CompleteMission(IMission mission)
    {
        throw new NotImplementedException();
    }
}