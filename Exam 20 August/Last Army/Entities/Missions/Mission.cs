using System;

public class Mission : IMission
{
    public string Name { get; set; }

    public double EnduranceRequired { get; set; }

    public double ScoreToComplete { get; set; }

    public double WearLevelDecrement { get; set; }

    public Mission(string name, double endurance, double score)
    {
        this.Name = name;
        this.EnduranceRequired = endurance;
        this.ScoreToComplete = score;
    }
}