using System.Collections;
using System.Text.Json.Serialization;

class Player : User
{
    public Hero PlayerCharacter {get; set;}


    [JsonConstructor] public Player() {}
    public Player(string username, string password) : base(username, password)
    {
        UserMenuOptions = new() {"View Party","My Character","Change Password","Main Menu"};
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
            else if (userNum > 0 && userNum < UserMenuOptions.Count)
            {
                switch (userNum)
                {
                    case 1:
                        Program._currentParty.PartyMenu();
                        break;
                    case 2:
                        ViewOwnCharacter();
                        break;
                    case 3:
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

    public void ViewOwnCharacter()
    {
        bool exit = false;
        do
        {
            Console.Clear();
            PlayerCharacter.PrintCreature();
            Console.WriteLine("\nPlease pick from the following options.\n1: Update Character\n2: Deposit Item to Stash\n3: Return to previous menu");
            if (int.TryParse(Console.ReadLine(), out int userNum) && userNum == 3)
            {
                exit = true;
            }
            else if (userNum == 1)
            {
                PlayerCharacter.UpdateCreature();
            }
            else if (userNum == 2)
            {
                StashItem(PlayerCharacter);
            }
            else
            {
                Console.WriteLine("Please enter a valid option from the list.\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
        while (!exit);
    }

    public void PrintCharacter()
    {
        Console.WriteLine($"Player: {Username}");
        PlayerCharacter.PrintCreature();
    }

    public void CreateCharacter()
    {
        string name, description;
        int level = 1;

        Console.Clear();
        Console.WriteLine("Please create your character. What is their name?");
        name = Console.ReadLine();
        Console.WriteLine("What level are they?");
        level = ProgramFunctions.PosIntChecker();

        Console.Clear();
        Console.WriteLine($"Please enter a brief description of {name}.");
        description = Console.ReadLine();

        PlayerCharacter = new Hero(name, level, description);
        JsonHandler.SaveData();
    }

    public override void ReceiveItem(KeyItem item)
    {
        PlayerCharacter.AddItem(item);
    }
}