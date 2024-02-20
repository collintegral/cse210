using System;

class Program
{
    static public List<Party> _parties;
    static public Party _currentParty;
    static public User _currentUser;


    static void Main(string[] args)
    {
        JsonHandler.LoadData();

        bool exit = false;
        do
        {
            _currentParty = null;
            _currentUser = null;
            Console.Clear();
            Console.WriteLine("Welcome to the TTRPG Party Manager! Select an option to get started.");

            if (_parties.Count != 0)
            {
                Console.WriteLine("1: Select Party\n2: Create New Party\n3: Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        ProgramFunctions.SelectParty();
                        _currentParty?.SelectUser();
                        _currentUser?.UserMenu();
                        break;
                    case "2":
                        ProgramFunctions.CreateNewParty();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option from the menu.\nPress any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
            else
            {
                Console.WriteLine("1: Create New Party\n2: Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        ProgramFunctions.CreateNewParty();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option from the menu.\nPress any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        while (!exit);
    }
}