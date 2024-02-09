using System.Text.Json.Serialization;

[JsonDerivedType(typeof(SingleGoal), typeDiscriminator: "singlegoal")]
[JsonDerivedType(typeof(RepeatGoal), typeDiscriminator: "repeatgoal")]
[JsonDerivedType(typeof(ComboGoal), typeDiscriminator: "combogoal")]
[JsonDerivedType(typeof(NumberedGoal), typeDiscriminator: "numberedgoal")]


class Goal
{
    [JsonInclude] public string Name {get; set;}
    [JsonInclude] public int PointWorth {get; set;}
    [JsonInclude] public bool Active {get; set;}
    [JsonInclude] public string GoalType {get; set;}

    [JsonConstructor] public Goal() {}
    
    public Goal(string name, int pointWorth, bool active)
    {
        Name = name;
        PointWorth = pointWorth;
        Active = active;
        GoalType = "Generic Goal";
    }


    public virtual void ChangeActive()
    {
        Active = !Active;
    }

    public virtual void PrintMenuGoal()
    {
        Console.Write($"{Name} - {GoalType}");
    }

    public virtual void PrintGoal()
    {
        if (Active)
        {
            Console.Write("Active ");
        }
        else
        {
            Console.Write("Archived ");
        }
        Console.WriteLine($"Goal Name: {Name}\nCompletion Value: {PointWorth}\nGoal Type: {GoalType}");
    }

    public virtual int CompleteGoal()
    {
        return PointWorth;
    }
}