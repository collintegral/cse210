using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Hero), typeDiscriminator: "hero")]
[JsonDerivedType(typeof(Monster), typeDiscriminator: "monster")]
[JsonDerivedType(typeof(Npc), typeDiscriminator: "npc")]

abstract class Creature
{
    public string Name {get; set;}
    public int Level {get; set;}
    public string Description {get; set;}
    public List<KeyItem> KeyItems {get; set;}
    public List<string> CreatureUpdateOptions {get; set;}


    [JsonConstructor] public Creature() {}
    public Creature(string name, int level, string description = "(No Description)")
    {
        Name = name;
        Level = level;
        Description = description;
        KeyItems = new() {};
    }

    public virtual void UpdateCreature()
    {
        Console.Clear();
        PrintCreature();
        Console.WriteLine("\nPlease pick from the following options.");
        foreach (var option in CreatureUpdateOptions.Select((value, index) => new {index, value}))
        {
            Console.WriteLine($"{option.index + 1}: {option.value}");
        }
        
        
    }

    public virtual void PrintCreature()
    {
        Console.WriteLine($"{Name} - Level {Level}\n{Description}\n\nItems: ");
        PrintItems();
    }

    public void PrintItems()
    {
        foreach (var item in KeyItems.Select((value, index) => new {index, value}))
        {
            Console.WriteLine($"{item.index + 1}: {item.value.StringItem()}");
        }
        if (KeyItems.Count == 0)
        {
            Console.WriteLine("None");
        }
    }

    public void AddItem(KeyItem item)
    {
        KeyItems.Add(item);
        JsonHandler.SaveData();
    }

    public void RemoveItem(int itemIndex)
    {
        KeyItems.RemoveAt(itemIndex);
        JsonHandler.SaveData();
    }

    public void ItemToStashMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            PrintItems();
            Console.WriteLine($"{KeyItems.Count + 1}: Previous Menu\n\nEnter a number to remove an item or return to the previous menu.");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == KeyItems.Count + 1)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum <= KeyItems.Count)
            {
                Program._currentUser.ReceiveItem(KeyItems[userNum - 1]);
                RemoveItem(userNum - 1);
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }
}