using System.Text.Json.Serialization;

class Monster : Creature
{
    public string Biome {get; set;}


    [JsonConstructor] public Monster() {}
    public Monster(string name, int level, string description, string biome) : base(name, level, description)
    {
        Biome = biome;
        CreatureUpdateOptions = new() {"Change Name", "Change Level", "Change Description", "Change Biome", "Take Item", "Previous Menu"};
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
                        Console.WriteLine($"Enter a new name for {Name}:");
                        Name = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 2:
                        Console.WriteLine($"Level {Level}\n\nEnter a new level for {Name}:");
                        Level = ProgramFunctions.PosIntChecker();
                        JsonHandler.SaveData();
                        break;
                    case 3:
                        Console.WriteLine($"{Description}\n\nEnter a new description for {Name}:");
                        Description = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 4:
                        Console.WriteLine($"{Name} can be found in {Biome}.\n\nEnter a new biome for {Name}:");
                        Biome = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 5:
                        ItemToStashMenu();
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
        Console.WriteLine($"\nBiome: {Biome}");
    }
}