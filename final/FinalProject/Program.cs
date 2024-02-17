using System;

class Program
{
    static public List<Party> _parties;
    static public User _currentUser;


    static void Main(string[] args)
    {
        JsonHandler.LoadData();

        bool exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the TTRPG Party Manager! Select an option to get started.");

            if (_parties.Count != 0)
            {
                Console.WriteLine("1: Log In\n2: Create New Player\n3: Create New Party\n4: Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        ProgramFunctions.SelectUser();
                        break;
                    case "2":
                        ProgramFunctions.CreateNewPlayer();
                        break;
                    case "3":
                        ProgramFunctions.CreateNewParty();
                        break;
                    case "4":
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