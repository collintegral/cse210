using System.Text.Json.Serialization;

[JsonDerivedType(typeof(ComboGoal), typeDiscriminator: "combogoal")]

class ComboGoal : RepeatGoal
{
    [JsonInclude] public int BonusWorth {get; set;}
    [JsonInclude] public int CompletionChain {get; set;}

    [JsonConstructor] public ComboGoal() {}
    
    public ComboGoal(string name, int pointWorth, int bonusWorth, bool active) : base(name, pointWorth, active)
    {
        BonusWorth = bonusWorth;
        CompletionChain = 0;
        GoalType = "Combo Goal";
    }


    public override void PrintMenuGoal()
    {
        base.PrintMenuGoal();
        Console.Write($" with a streak of {CompletionChain}");
    }

    public override void PrintGoal()
    {
        base.PrintGoal();
        Console.WriteLine($"Current Streak: {CompletionChain}\nCurrent Completion Bonus: {BonusWorth * CompletionChain}");
    }

    public override int CompleteGoal()
    {
        TimesCompleted++;
        string userInput;
        do
        {
            Console.WriteLine("Did you continue your streak [y/n]? ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "y")
            {
                 CompletionChain++;
                 Console.WriteLine($"Good job! That's worth {BonusWorth * CompletionChain} bonus points.");
            }
            else if (userInput.ToLower() == "n")
            {
                CompletionChain = 0;
                Console.WriteLine("That's alright, start building back your streak!");
            }
            else
            {
                Console.WriteLine("Please enter either \"y\" or \"n\": ");
            }
        }
        while (userInput.ToLower() != "y" && userInput.ToLower() != "n");

        return PointWorth + (BonusWorth * CompletionChain);
    }
}