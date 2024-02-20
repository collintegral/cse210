using System.Text.Json.Serialization;
using Microsoft.VisualBasic.FileIO;

class KeyItem
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Value {get; set;}
    public List<string> ItemUpdateOptions {get; set;}

    
    [JsonConstructor] public KeyItem() {}
    public KeyItem(string name, int value, string description)
    {
        Name = name;
        Description = description;
        Value = value;
        ItemUpdateOptions = new() {"Change Name", "Change Value", "Change Description", "Assign Item", "Delete Item", "Previous Menu"};
    }


    public string StringItem()
    {
        return $"{Name} (worth {Value}): {Description}";
    }

    public char UpdateItem()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine($"{StringItem()}\n");

            foreach (var option in ItemUpdateOptions.Select((value, index) => new {index, value}))
            {
                Console.WriteLine($"{option.index + 1}: {option.value}");
            }

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == ItemUpdateOptions.Count)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum <= ItemUpdateOptions.Count)
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
                        Console.WriteLine($"Value: {Value}\n\nEnter a new value for {Name}:");
                        Value = ProgramFunctions.PosIntChecker();
                        JsonHandler.SaveData();
                        break;
                    case 3:
                        Console.WriteLine($"{Description}\n\nEnter a new description for {Name}:");
                        Description = Console.ReadLine();
                        JsonHandler.SaveData();
                        break;
                    case 4:
                        return 'a';
                    case 5:
                        return 'd';

                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
        return 'n';
    }
}