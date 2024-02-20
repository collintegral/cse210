using System.Text.Json.Serialization;

class Gm : User
{
    public List<Npc> ImportantNpcs {get; set;}
    public List<Monster> Monsters {get; set;}
    public List<KeyItem> UnassignedItems {get; set;}


    [JsonConstructor] public Gm() {}
    public Gm(string username, string password) : base(username, password)
    {
        ImportantNpcs = new () {};
        Monsters = new () {};
        UnassignedItems = new () {};
        UserMenuOptions = new() {"View Party","NPC Menu","Monster Menu","Item Menu","Change Password","Main Menu"};
    }


    public override void UserMenu()
    {
        bool exit = false;
        do
        {
            base.UserMenu();
            
            string userChoice = Console.ReadLine();
            if (int.TryParse(userChoice, out int userNum) && userNum == UserMenuOptions.Count)
            {
                exit = true;
            }
            else if (userNum >= 0 && userNum < UserMenuOptions.Count)
            {
                switch (userNum)
                {
                    case 1:
                        Program._currentParty.PartyMenu();
                        break;
                    case 2:
                        NpcListMenu();
                        break;
                    case 3:
                        MonsterListMenu();
                        break;
                    case 4:
                        ItemListMenu();
                        break;
                    case 5:
                        ChangePassword();
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

    public void ListNpcs()
    {
        foreach (var npc in ImportantNpcs.Select((value, index) => (index, value)))
        {
            Console.Write($"\n{npc.index + 1}: ");
            npc.value.PrintCreature();
        }
    }

    public void NpcListMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            ListNpcs();
            Console.WriteLine($"\n{ImportantNpcs.Count + 1}: Create New Npc\n{ImportantNpcs.Count + 2}: Previous Menu\nSelect a number to update an NPC, create a new one, or return to the previous menu.");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == ImportantNpcs.Count + 2)
            {
                exit = true;
            }
            else if (userNum == ImportantNpcs.Count + 1)
            {
                CreateNpc();
                Console.WriteLine("NPC successfully created.\nPress any key to continue...");
                        Console.ReadKey(true);
            }
            else if (userNum > 0 && userNum <= ImportantNpcs.Count)
            {
                ImportantNpcs[userNum - 1].UpdateCreature();
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public void ListMonsters()
    {
        foreach (var monster in Monsters.Select((value, index) => (index, value)))
        {
            Console.Write($"\n{monster.index + 1}: ");
            monster.value.PrintCreature();
        }
    }

    public void MonsterListMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            
            ListMonsters();
            Console.WriteLine($"\n{Monsters.Count + 1}: Create New Monster\n{Monsters.Count + 2}: Previous Menu\nSelect a number to update a monster, create a new one, or return to the previous menu.");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == Monsters.Count + 2)
            {
                exit = true;
            }
            else if (userNum == Monsters.Count + 1)
            {
                CreateMonster();
                Console.WriteLine("Monster successfully created.\nPress any key to continue...");
                        Console.ReadKey(true);
            }
            else if (userNum > 0 && userNum <= Monsters.Count)
            {
                Monsters[userNum - 1].UpdateCreature();
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public void ItemListMenu()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            try
            {
                foreach (var item in UnassignedItems.Select((value, index) => new {index, value}))
                {
                    Console.WriteLine($"{item.index + 1}: {item.value.StringItem()}");
                }
                Console.WriteLine($"{UnassignedItems.Count + 1}: New Item\n{UnassignedItems.Count + 2}: Previous Menu\n\nSelect a number to update an item, create a new one, or return to the previous menu.");
            }
            catch
            {
                Console.WriteLine("There are no currently unassigned items.");
                Console.WriteLine($"1: New Item\n2: Previous Menu\n\nSelect a number to create an item or return to the previous menu.");
            }

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == UnassignedItems.Count + 2)
            {
                exit = true;
            }
            else if (userNum == UnassignedItems.Count + 1)
            {
                CreateItem();
                Console.WriteLine("Item successfully created.\nPress any key to continue...");
                        Console.ReadKey(true);
            }
            else if (userNum > 0 && userNum <= UnassignedItems.Count)
            {
                char response = UnassignedItems[userNum - 1].UpdateItem();
                if ( response == 'a')
                {
                    if (AssignItem(UnassignedItems[userNum - 1]))
                    {
                        RemoveItem(userNum - 1);
                        Console.WriteLine("Item successfully assigned.\nPress any key to continue...");
                        Console.ReadKey(true);
                    }
                }
                else if (response == 'd')
                {
                    RemoveItem(userNum - 1);
                    Console.WriteLine("Item successfully deleted.\nPress any key to continue...");
                        Console.ReadKey(true);
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

    public void CreateMonster()
    {
        Console.Clear();
        Console.WriteLine("Enter a name for the new monster.");
        string name = Console.ReadLine();
        Console.WriteLine("Enter a level for the monster.");
        int level = ProgramFunctions.PosIntChecker();
        Console.WriteLine("Enter a description for the new monster.");
        string description = Console.ReadLine();
        Console.WriteLine("What biome does this monster reside in?");
        string biome = Console.ReadLine();

        Monsters.Add(new Monster(name, level, description, biome));
        JsonHandler.SaveData();
    }
    
    public void CreateNpc()
    {
        Console.Clear();
        Console.WriteLine("Enter a name for the new NPC.");
        string name = Console.ReadLine();
        Console.WriteLine("Enter a level for the NPC.");
        int level = ProgramFunctions.PosIntChecker();
        Console.WriteLine("Enter a description for the new NPC.");
        string description = Console.ReadLine();

        ImportantNpcs.Add(new Npc(name, level, description));
        JsonHandler.SaveData();
    }

    public void CreateItem()
    {
        Console.Clear();
        Console.WriteLine("Enter a name for the new item.");
        string name = Console.ReadLine();
        Console.WriteLine("Enter a gold value for the item.");
        int value = ProgramFunctions.PosIntChecker();
        Console.WriteLine("Enter a description for the new item.");
        string description = Console.ReadLine();

        UnassignedItems.Add(new KeyItem(name, value, description));
        JsonHandler.SaveData();
    }

    public bool AssignItem(KeyItem item)
    {
        bool exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine($"{item.StringItem()}\n\n1: Assign to a Monster\n2: Assign to an NPC\n3: Assign to Party Stash");

            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == 1)
            {
                ListMonsters();
                if (int.TryParse(Console.ReadLine(), out int monsterNum) && monsterNum <= Monsters.Count && monsterNum > 0)
                {
                    Monsters[monsterNum - 1].AddItem(item);
                    return true;
                }
                else 
                {
                    Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                    Console.ReadKey(true);
                }
            }
            else if (userNum == 2)
            {
                ListNpcs();
                if (int.TryParse(Console.ReadLine(), out int npcNum) && npcNum <= ImportantNpcs.Count && npcNum > 0)
                {
                    ImportantNpcs[npcNum - 1].AddItem(item);
                    return true;
                }
                else 
                {
                    Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                    Console.ReadKey(true);
                }
            }
            else if (userNum == 3)
            {
                Program._currentParty.AddToStash(item);
                return true;
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
        return false;
    }

    public void RemoveItem(int itemIndex)
    {
        UnassignedItems.RemoveAt(itemIndex);
        JsonHandler.SaveData();
    }

    public override void ReceiveItem(KeyItem item)
    {
        UnassignedItems.Add(item);
        JsonHandler.SaveData();
    }
}