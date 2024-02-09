using System;
using System.Net.Quic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;

/*
This week, I went beyond the requirements of the assignment by allowing for multiple users,
as well as by introducing another type of goal - the Combo Goal, which is worth more points the more times in a row the user completes it (self-reported).
*/

class Program
{
    const string _filePath = "userlist.json";
    static readonly JsonSerializerOptions options = new() {WriteIndented = true, IncludeFields = true};
    static List<User> _usersList = new();
    static User _user;

    static readonly List<string> goalTypes = new() {"Single Goal - Complete a single time", "Repeated Goal - Complete indefinitely", "Combo Goal - Complete indefinitely, with bonus points for good habits", "Numbered Goal - Complete a number of times"};


    static void Main(string[] args)
    {
        LoadUserList();
        string userChoice;
        
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Eternal Quest, your personal goal tracking assistant.\nPlease select from the following options: \n");

            if(_usersList.Count > 0)
            {
                Console.WriteLine("1:  New User\n2:  Returning User\n3:  Exit\n");
            }
            else
            {
                Console.WriteLine("1:  New User\n2:  Exit\n");
            }
            
            userChoice = Console.ReadLine();
            if(userChoice == "1")
            {
                bool quit = NewUser();
                if (quit) {break;}
            }
            else if (userChoice == "2" && _usersList.Count > 0)
            {
                bool quit = LoadUser();
                if (quit) {break;}
            }           
        }
        while (userChoice.ToLower() != "exit" && ((_usersList.Count > 0 && userChoice != "3") || (_usersList.Count == 0 && userChoice != "2")));
    }


    static bool NewUser()
    {
        string userInput;
        bool userSaved = false;

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome! To get started, please enter a username, or type \"main\" to return to the main menu: ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "main")
            {
                if (_usersList.Count > 0)
                {
                    foreach(User user in _usersList)
                    {
                        if (userInput.ToLower() == user.Username.ToLower())
                        {
                            Console.WriteLine("This username is taken. Please try again.\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            var newUser = new User
                            {
                                Username = userInput,
                                Points = 0,
                                Goals = new()
                            };
                            _usersList.Add(newUser);
                            SaveUserList();
                            userSaved = true;
                            _user = _usersList.Last();
                            GoalMenu();
                            break;
                        }
                    }
                }
                else
                {
                    var newUser = new User
                    {
                        Username = userInput,
                        Points = 0,
                        Goals = new()
                    };
                    _usersList.Add(newUser);
                    SaveUserList();
                    userSaved = true;
                    _user = _usersList.Last();
                    GoalMenu();
                }
            }
            
        }
        while (userInput.ToLower() != "main" && !userSaved);

        if (userInput.ToLower() == "main")
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    static bool LoadUser()
    {
        string userChoice;
        List<string> usernames = new();
        _usersList.ForEach(user => {
            usernames.Add(user.Username);
        });

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome back! To get started, please select your username or type \"main\" to return to the main menu: \n");

            int i = 0;
            usernames.ForEach(name => {
                Console.WriteLine($"{i+1}: {name}");
                i++;
            });            

            Console.WriteLine();
            userChoice = Console.ReadLine();

            bool isNum = int.TryParse(userChoice, out int userNum);

            if (isNum)
            {
                if (userNum <= usernames.Count)
                {
                    _user = _usersList[userNum - 1];
                    GoalMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease select a valid number from the user list, or type \"main\" to return to the main menu.\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            else if (userChoice.ToLower() != "main")
            {
                Console.WriteLine("\nPlease select a valid number from the user list, or type \"main\" to return to the main menu.\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        while (userChoice.ToLower() != "main");

        if (userChoice.ToLower() == "main")
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    static void GoalMenu()
    {
        string userInput;
        bool hasGoals;
        do
        {
            Console.Clear();
            Console.WriteLine($"Welcome to Eternal Quest, your personal goal tracking assistant.\nYou currently have {_user.Points}.\n\nPlease select from the following options: ");

            if (_user.Goals.Count == 0)
            {
                hasGoals = false;
                Console.WriteLine("1: New Goal\n2: Exit");
            }
            else
            {
                hasGoals = true;
                Console.WriteLine("1: New Goal\n2: View Active Goals\n3: View Archived Goals\n4: Exit");
            }

            userInput = Console.ReadLine();

            if(hasGoals)
            {
                switch (userInput)
                {
                    case "1":
                        NewGoalMenu();
                        break;
                    case "2":
                        ViewGoalsMenu(true);
                        break;
                    case "3":
                        ViewGoalsMenu(false);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number from the list.\nPress any key to continue.");
                        Console.ReadKey(true);
                        break;
                }
            }
            else
            {
                switch (userInput)
                {
                    case "1":
                        NewGoalMenu();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number from the list.\nPress any key to continue.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        while (userInput.ToLower() != "exit" && ((hasGoals && userInput != "4") || (!hasGoals && userInput != "2")));
    }


    static void NewGoalMenu()
    {
        string userInput;

        do
        {
            Console.Clear();
            Console.WriteLine("Select the type of goal you would like to add, or type \"menu\" to return to the goal menu:\n");

            int i = 0;
            goalTypes.ForEach(goalType => {
                Console.WriteLine($"{i+1}: {goalType}");
                i++;
            });

            userInput = Console.ReadLine();     

            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
            {
                CreateGoal(userInput);
                Console.Clear();
                Console.WriteLine("Goal created successfully. Would you like to create another [y/n]?");
                if (Console.ReadLine().ToLower() == "n")
                {
                    userInput = "menu";
                }
            }
            else if (userInput.ToLower() != "menu")
            {
                    Console.WriteLine("Invalid choice. Please select a number from the list, or type \"menu\" to return to the goal menu.\nPress any key to continue.");
                    Console.ReadKey(true);
            }
        }
        while (userInput.ToLower() != "menu");
    }


    static void CreateGoal(string type)
    {
        switch(type)
            {
                case "1":
                {
                    Console.Clear();
                    Console.WriteLine("Name your new Single Goal: ");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("Input the point value of this goal: ");
                    int goalValue = int.Parse(Console.ReadLine());
                    var newGoal = new SingleGoal(goalName, goalValue, true);
                    _user.Goals.Add(newGoal);
                    break;
                }
                case "2":
                {
                    Console.Clear();
                    Console.WriteLine("Name your new Repeated Goal: ");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("Input the point value of this goal: ");
                    int goalValue = int.Parse(Console.ReadLine());
                    var newGoal = new RepeatGoal(goalName, goalValue, true);
                    _user.Goals.Add(newGoal);
                    break;
                }
                case "3":
                {  
                    Console.Clear();
                    Console.WriteLine("Name your new Combo Goal: ");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("Input the point value of this goal: ");
                    int goalValue = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input the combo multiplier of this goal (bonus points you receive for each completion in a row): ");
                    int comboValue = int.Parse(Console.ReadLine());
                    var newGoal = new ComboGoal(goalName, goalValue, comboValue, true);
                    _user.Goals.Add(newGoal);
                    break;
                }
                case "4":
                {  
                    Console.Clear();
                    Console.WriteLine($"Name your new Numbered Goal: ");
                    string goalName = Console.ReadLine();
                    Console.WriteLine("Input the point value for each completion of this goal: ");
                    int goalValue = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input the number of times you'll need to complete this goal: ");
                    int completions = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input the bonus points you'll get for fully completing the goal: ");
                    int finalBonus = int.Parse(Console.ReadLine());
                    var newGoal = new NumberedGoal(goalName, goalValue, completions, finalBonus, true);
                    _user.Goals.Add(newGoal);
                    break;
                }
            }
        SaveUserList();
    }


 static void ViewGoalsMenu(bool active)
    {
        string userInput;
        int i;
        int goalIndex;
        List<int> goalIndexList = new();

        do
        {
            i = 0;
            goalIndex = 0;
            goalIndexList.Clear();

            Console.Clear();
            if (active)
            {
                Console.WriteLine("Active Goals: ");
                _user.Goals.ForEach(goal => {
                    if (goal.Active)
                    {
                        Console.Write($"\n{i+1}: ");
                        goal.PrintMenuGoal();
                        
                        goalIndexList.Add(goalIndex);
                        i++;
                    }
                    goalIndex++;
                });
            }
            else
            {
                Console.WriteLine("Archived Goals: ");
                _user.Goals.ForEach(goal => {
                    if (!goal.Active)
                    {
                        Console.Write($"\n{i+1}: ");
                        goal.PrintMenuGoal();
                        
                        goalIndexList.Add(goalIndex);
                        i++;
                    }
                    goalIndex++;
                });
            }

            Console.Write("\nSelect a goal, or type \"menu\" to return to the previous menu: ");
            userInput = Console.ReadLine();
            bool isNum = int.TryParse(userInput, out int userNum);

            if (isNum)
            {
                if (userNum <= _user.Goals.Count)
                {
                    ViewGoal(goalIndexList[userNum-1]);
                }
                else
                {
                    Console.WriteLine("\nPlease select a valid number from the goals list, or type \"main\" to return to the previous menu.\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            else if (userInput.ToLower() != "menu")
            {
                Console.WriteLine("\nPlease select a valid number from the goals list, or type \"main\" to return to the previous menu.\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        while (userInput.ToLower() != "menu");
    }


    static void ViewGoal(int goalIndex)
    {
        var currentGoal = _user.Goals[goalIndex];
        string userInput;

        do
        {
        Console.Clear();
        currentGoal.PrintGoal();

        Console.WriteLine("\nPlease select from the following options:\n1: Mark Completion\n2: Archive/Activate Goal\n3: Return to Previous Menu");
        userInput = Console.ReadLine();

            
            if (userInput == "1")
            {
                Console.Clear();
                int addPoints = currentGoal.CompleteGoal();
                _user.Points += addPoints;
                SaveUserList();
                Console.WriteLine($"Congratulations, you've gained {addPoints}, for a total of {_user.Points} points.\nPress any key to return to the previous menu...");
                Console.ReadKey(true);
            }
            else if (userInput == "2")
            {
                currentGoal.ChangeActive();
                SaveUserList();
                Console.Clear();
                if (currentGoal.Active)
                {
                   Console.WriteLine($"This goal has been successfully retrieved from archive.\nPress any key to return to the previous menu..."); 
                }
                else
                {
                    Console.WriteLine($"This goal has been successfully archived.\nPress any key to return to the previous menu..."); 
                }
                Console.ReadKey(true);
            }
            else if (userInput != "3" && userInput.ToLower() != "menu")
            {
                Console.WriteLine("\nPlease select a valid number from the goals list, or type \"main\" to return to the previous menu.\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        while(userInput != "3" && userInput.ToLower() != "menu");

        _user.Goals[goalIndex] = currentGoal;
    }

    static void LoadUserList()
    {
        var fileTest = new FileInfo(_filePath);

        if (!fileTest.Exists)
        {
            File.Create(_filePath).Dispose();
        }
        else if (File.ReadAllText(_filePath).Length != 0)
        {
            _usersList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_filePath), options);
        }
    }


    static void SaveUserList()
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_usersList, options));
    }
}