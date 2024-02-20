using System.Text.Json.Serialization;

class Hero : Creature
{
    public List<string> Abilities {get; set;}


    [JsonConstructor] public Hero() {}
    public Hero(string name, int level, string description) : base(name, level, description)
    {
        CreatureUpdateOptions = new() {"Change Name", "Change Level", "Change Description", "Add Ability", "Previous Menu"};
        Abilities = new() {};
    }


    public override void UpdateCreature()
    {
        bool exit = false;
        do
        {
            base.UpdateCreature();

            string userChoice = Console.ReadLine();
            if (int.TryParse(userChoice, out int userNum) && userNum == CreatureUpdateOptions.Count)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum < CreatureUpdateOptions.Count)
            {
                Console.Clear();
                switch (userNum)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Enter a new name for {Name}:");
                        Name = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Level {Level}\n\nEnter a new level for {Name}:");
                        Level = ProgramFunctions.PosIntChecker();
                        JsonHandler.SaveData();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"{Description}\n\nEnter a new description for {Name}:");
                        Description = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 4:
                        Console.Clear();
                        PrintAbilities();
                        Console.WriteLine($"Add a new ability for {Name}, or type 'exit' to cancel:");
                        string ability = Console.ReadLine();
                        if (ability.ToLower() == "exit")
                        {
                            break;
                        }
                        else
                        {
                            Abilities.Add(ability);
                            JsonHandler.SaveData();
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public override void PrintCreature()
    {
        base.PrintCreature();
        Console.WriteLine("\nAbilities:");
        PrintAbilities();
    }

    public void PrintAbilities()
    {
        foreach (var ability in Abilities.Select((value, index) => new {index, value}))
        {
            Console.WriteLine($"{ability.index + 1}: {ability.value}");
        }
        if (Abilities.Count == 0)
        {
            Console.WriteLine("None");
        }
    }
}