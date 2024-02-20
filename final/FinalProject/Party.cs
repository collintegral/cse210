using System.Text.Json.Serialization;

class Party
{
    public string Name {get; set;}
    public Gm Gm {get; set;}
    public List<Player> Players {get; set;}
    public List<KeyItem> Stash {get; set;}
    

    [JsonConstructor] public Party() {}

    public Party(string name, Gm gm)
    {
        Name = name;
        Gm = gm;
        Players = new() {};
        Stash = new() {};
    }


    public void SelectUser()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine($"Select a user for login.\n1: {Gm.Username} (GM)");

            if (Players.Count > 0)
            {
                foreach (var player in Players.Select((value, index) => new {index, value}))
                {
                    Console.WriteLine($"{player.index + 2}: {player.value.Username}");
                }
            }
            Console.WriteLine($"{Players.Count + 2}: New Player\n{Players.Count + 3}: Main Menu");

            string userChoice = Console.ReadLine();
                
            if (int.TryParse(userChoice, out int userNum) && userNum == 1)
            {
                if (Gm.CheckPassword())
                {
                    Program._currentUser = Gm;
                    break;
                }
            }
            else if (userNum > 0 && userNum < Players.Count + 2)
            {
                if (Players[userNum - 2].CheckPassword())
                {
                    Program._currentUser = Players[userNum - 2];
                    break;
                }
            }
            else if (userNum == Players.Count + 2)
            {
                AddPlayer();
            }
            else if (userNum == Players.Count + 3)
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public void AddPlayer()
    {
        Console.Clear();
        Console.WriteLine("Please enter your new username.");
        string username = Console.ReadLine();
        Console.WriteLine("Please enter your password.");
        string password = Console.ReadLine();

        Players.Add(new(username, password));
        Players.Last().CreateCharacter();
    }

    public void DisplayParty()
    {
        Console.WriteLine("Players:");
        foreach (var player in Players.Select((value, index) => new {index, value}))
        {
            Console.WriteLine($"{player.index + 1}: {player.value.Username} - {player.value.PlayerCharacter.Name}");
        }
    }

    public void DisplayStash()
    {
        Console.WriteLine("Party Stash:");
        foreach (var item in Stash.Select((value, index) => (index, value)))
        {
            Console.WriteLine($"{item.index + 1}: {item.value.StringItem()}");
        }
        if (Stash.Count == 0)
        {
            Console.WriteLine("No Items");
        }
    }

    public void PartyMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            DisplayParty();
            Console.WriteLine($"{Players.Count + 1}: View Item Stash\n{Players.Count + 2}: Previous Menu");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == Players.Count + 2)
            {
                exit = true;
            }
            else if (userNum == Players.Count + 1)
            {
                StashMenu();
            }
            else if (userNum > 0 && userNum <= Players.Count)
            {
                Console.Clear();
                Players[userNum - 1].PrintCharacter();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);

        
    }

    public void StashMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            DisplayStash();
            Console.WriteLine($"\n{Stash.Count + 1}: Previous Menu\n\nSelect a number to take an item, or exit.");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == Stash.Count + 1)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum <= Stash.Count)
            {
                Program._currentUser.ReceiveItem(Stash[userNum - 1]);
                RemoveFromStash(userNum - 1);
                Console.WriteLine("Item received.\nPress any key to continue...");
                Console.ReadKey(true);
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

    public void RemoveFromStash(int itemIndex)
    {
       Stash.RemoveAt(itemIndex);
       JsonHandler.SaveData();
    }
    
    public void AddToStash(KeyItem item)
    {
        Stash.Add(item);
        JsonHandler.SaveData();
    }
}