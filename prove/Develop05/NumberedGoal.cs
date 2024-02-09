using System.Text.Json.Serialization;

[JsonDerivedType(typeof(NumberedGoal), typeDiscriminator: "numberedgoal")]

class NumberedGoal : RepeatGoal
{
    [JsonInclude] public int BonusWorth {get; set;}
    [JsonInclude] public int CompletionsNeeded {get; set;}

    [JsonConstructor] public NumberedGoal() {}
    
    public NumberedGoal(string name, int pointWorth, int completionsNeeded, int finalBonus, bool active) : base (name, pointWorth, active)
    {
        BonusWorth = finalBonus;
        CompletionsNeeded = completionsNeeded;
        GoalType = "Numbered Goal";
    }


    public override void PrintMenuGoal()
    {
        base.PrintMenuGoal();
        Console.Write($" out of {CompletionsNeeded}");
    }

    public override void PrintGoal()
    {
        base.PrintGoal();
        Console.WriteLine($"Completions Still Required: {CompletionsNeeded}");
    }

    public override int CompleteGoal()
    {
        TimesCompleted++;
        if (TimesCompleted >= CompletionsNeeded)
        {
            ChangeActive();
            Console.WriteLine("You've completed this goal!");
            return PointWorth + BonusWorth;
        }
        else
        {
            Console.WriteLine($"You need ${CompletionsNeeded - TimesCompleted} more completions.");
            return PointWorth;
        }
        
    }
}