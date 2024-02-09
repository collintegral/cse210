using System.Text.Json.Serialization;

[JsonDerivedType(typeof(RepeatGoal), typeDiscriminator: "repeatgoal")]

class RepeatGoal : Goal
{
    [JsonInclude] public int TimesCompleted {get; set;}

    [JsonConstructor] public RepeatGoal() {}
    
    public RepeatGoal(string name, int pointWorth, bool active) : base (name, pointWorth, active)
    {
        TimesCompleted = 0;
        GoalType = "Repeated Goal";
    }


    public override void ChangeActive()
    {
        base.ChangeActive();
        if (Active)
        {
            TimesCompleted = 0;
        }
    }

    public override void PrintMenuGoal()
    {
        base.PrintMenuGoal();
        Console.Write($" - Completed {TimesCompleted} times");
    }

    public override void PrintGoal()
    {
        base.PrintGoal();
        Console.WriteLine($"Times Completed: {TimesCompleted}");
    }

    public override int CompleteGoal()
    {
        TimesCompleted++;
        Console.WriteLine($"You've now completed this goal {TimesCompleted} times.");
        return PointWorth;
    }
}