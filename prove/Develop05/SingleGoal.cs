using System.Text.Json.Serialization;

[JsonDerivedType(typeof(SingleGoal), typeDiscriminator: "singlegoal")]

class SingleGoal : Goal
{
    [JsonConstructor] public SingleGoal() {}
    
    public SingleGoal(string name, int pointWorth, bool active) : base (name, pointWorth, active)
    {
        GoalType = "Single Goal";
    }
    

    public override int CompleteGoal()
    {
        ChangeActive();
        Console.WriteLine("Well done, you've completed this goal!");
        return PointWorth;
    }
}