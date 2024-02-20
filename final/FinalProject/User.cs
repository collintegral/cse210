using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Gm), typeDiscriminator: "gm")]
[JsonDerivedType(typeof(Player), typeDiscriminator: "player")]

abstract class User
{
    public string Username {get; set;}
    public string Password {get; set;}
    public List<string> UserMenuOptions {get; set;}


    [JsonConstructor] public User() {}
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }


    public virtual void UserMenu()
    {
        Console.Clear();
        Console.WriteLine($"Welcome, {Username}. Please pick from the following options.");
        foreach (var option in UserMenuOptions.Select((value, index) => new {index, value}))
        {
            Console.WriteLine($"{option.index + 1}: {option.value}");
        }        
    }

    public void PlayerView(Player player)
    {
            Console.Clear();
            Console.WriteLine($"Player: {player.Username}");
            player.PlayerCharacter.PrintCreature();

            Console.WriteLine("\nPress any key to return to the previous menu...");
            Console.ReadKey(true);
    }

    public bool CheckPassword()
    {
        bool exit = false;
        string password;
        do
        {
            Console.Clear();
            Console.WriteLine("Please confirm your password.");
            password = Console.ReadLine();
            if (Password == password)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect password.\n\n1: Try again\n2: Return to previous menu");
                
                if (Console.ReadLine() != "1")
                {
                    exit = true;
                }
            }
        }
        while (!exit);
        return false;
    }

    public void ChangePassword()
    {
        if(CheckPassword())
        {
            Console.Clear();
            Console.WriteLine("Please enter your new password.");
            Password = Console.ReadLine();
            JsonHandler.SaveData();
        }
    }

    public void StashItem(Creature targetCreature)
    {
        bool exit = false;
        do
        {
            Console.Clear();
            foreach (var item in targetCreature.KeyItems.Select((value, index) => new {index, value}))
            {
                Console.WriteLine($"{item.index + 1}: {item.value.StringItem()}");
            }
            Console.WriteLine($"{targetCreature.KeyItems.Count + 1}: Return to Previous Menu");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == targetCreature.KeyItems.Count + 1)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum <= targetCreature.KeyItems.Count)
            {
                KeyItem item = targetCreature.KeyItems[userNum - 1];
                Program._currentParty.AddToStash(item);
                targetCreature.RemoveItem(userNum - 1);
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public abstract void ReceiveItem(KeyItem item);
}