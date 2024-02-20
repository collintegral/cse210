using Microsoft.VisualBasic;

static class ProgramFunctions
{
    public static void SelectParty()
    {
        Console.Clear();
        Console.WriteLine("Select your party from the following list.");

        int partyCount = Program._parties.Count;
        bool exit = false;

        do
        {

            foreach (var party in Program._parties.Select((value, index) => new {index, value}))
            {
                Console.WriteLine($"{party.index + 1}: {party.value.Name}");
            }
            
            Console.WriteLine($"{partyCount + 1}: Exit");

            string userChoice = Console.ReadLine();
            
            if (int.TryParse(userChoice, out int userNum) && userNum == partyCount + 1)
            {
                exit = true;
            }
            else if (userNum > 0 && userNum < partyCount + 1)
            {
                Program._currentParty = Program._parties[userNum - 1];
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

    public static void CreateNewParty()
    {
        Console.Clear();
        Console.WriteLine("What is your party's name?");
        string name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"What is the name of the GM for {name}?");
        string gmName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"What is {gmName}'s password?");
        string gmPassword = Console.ReadLine();

        Gm newGm = new(gmName, gmPassword);
        Party newParty = new(name, newGm);

        Program._parties.Add(newParty);
        JsonHandler.SaveData();
        
        Console.Clear();
        Console.WriteLine($"Party {Program._parties.Last().Name} created successfully, led by {Program._parties.Last().Gm.Username}.\nPress any key to return to main menu.");
        Console.ReadKey(true);
    }

    public static int PosIntChecker()
    {
        bool valueChosen = false;
        do
        {
            if (valueChosen = int.TryParse(Console.ReadLine(), out int userNum) && userNum > 0)
            {
                return userNum;
            }
            else
            {
                Console.WriteLine($"Please enter a positive integer.\nPress any key to continue...");
                Console.ReadKey(true);
                Console.SetCursorPosition(0, Console.CursorTop);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }
        while (!valueChosen);
        return 0;
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
