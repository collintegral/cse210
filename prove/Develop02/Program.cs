using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.VisualBasic;

static class Program
{
    const string _filePath = "JournalEntries.json";
    static bool _journalLoaded = false;
    static List<Journal> _savedJournals;
    static Journal _currentJournal = new Journal();
    static List<string> _writingPrompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was something unusual or different I noticed today?",
        "What ideas or topics caught my interest today?"};
    static Random rng = new Random();

    static void Main(string[] args)
    {
        LoadJournalJson();
        MainMenu();
    }

    public static void MainMenu()
    {
        Console.Clear();
        Console.Write(@$"== Main Menu ==
1) Write Journal Entry for Today
2) Display Loaded Journal
3) Save Journal to File
4) Load Journal from File
5) Exit Program
    
Please select an option from the menu: ");
        var userChoice = Console.ReadKey();

        switch (userChoice.KeyChar)
        {
            case '1':
                WriteJournal();
                break;
            case '2':
                ReadJournal();
                break;
            case '3':
                SaveJournal();
                break;
            case '4':

                LoadJournal();
                break;
            case '5':
                break;
            default:
                Console.WriteLine("\nPlease select a valid option from the menu.");
                Thread.Sleep(1000);
                MainMenu();
                break;
        }
    }

    static void WriteJournal()
    {
        Console.Clear();
        
        if (!_journalLoaded)
        {
            Console.WriteLine("No journal open. Creating a new journal...\n");
            _journalLoaded = true;
        }

        string currentPrompt = _writingPrompts[rng.Next(_writingPrompts.Count)];
        Console.WriteLine($"Prompt: {currentPrompt}\nWrite your response and press Enter when done: ");
        string currentContent = Console.ReadLine();

        _currentJournal.AddEntry(currentPrompt, currentContent);
        Console.WriteLine("Entry saved. Press any key to return to main menu.");
        Console.ReadKey(true);
        MainMenu();
        return;
    }

    static void ReadJournal()
    {
        Console.Clear();
        if (_journalLoaded)
        {
            _currentJournal.DisplayJournal();
        }
        else
        {
            Console.WriteLine("No journal open. Cannot read. Press any key to return to main menu.");
            Console.ReadKey(true);
        }
        MainMenu();
        return;
    }

    static void SaveJournal()
    {
        Console.Clear();
        
        if (_journalLoaded)
        {
            var options = new JsonSerializerOptions {WriteIndented = true};
            if (_currentJournal._journalName == "")
            {
                Console.WriteLine("Enter a name for your new journal: ");
                _currentJournal._journalName = Console.ReadLine();
            }

            int journalIndex = _savedJournals.FindIndex(s => s._journalName == _currentJournal._journalName);
            if (journalIndex == -1)
            {
                _savedJournals.Add(_currentJournal);
            }
            else
            {
                _savedJournals[journalIndex] = _currentJournal;
            }

            File.WriteAllText(_filePath, JsonSerializer.Serialize(_savedJournals, options));
            Console.WriteLine("Journal successfully saved. Press any key to return to main menu.");
        }

        else
        {
            Console.WriteLine("No journal open. Cannot save. Press any key to return to main menu.");
        }
        Console.ReadKey(true);
        MainMenu();
        return;
    }

    static void LoadJournal()
    {
        Console.Clear();

        if (_savedJournals.Count == 0)
        {
            Console.WriteLine("You don't have any journals saved. Why not write one?\nPress any key to return to main menu.");
            Console.ReadKey(true);
            MainMenu();
            return;
        }

        int i = 0;
        foreach (Journal journal in _savedJournals)
        {
            i++;
            Console.WriteLine($"{i}) {journal._journalName}");
        }

        Console.Write("\nEnter the number of the journal you would like to load, or enter 'menu' to return to main menu: ");
        string loadName = Console.ReadLine();

        if (loadName == "menu")
        {
            MainMenu();
            return;
        }

        if (int.Parse(loadName) <= _savedJournals.Count)
        {
            _currentJournal = _savedJournals[int.Parse(loadName)-1];
            _journalLoaded = true;
            Console.Clear();
            Console.WriteLine($"{_currentJournal._journalName} successfully loaded. Press any key to return to main menu.");
        }

        Console.ReadKey(true);
        MainMenu();
        return;
    }

    static void LoadJournalJson()
    {
        var fileTest = new FileInfo(_filePath);
        _savedJournals = new List<Journal>();

        if (!fileTest.Exists)
        {
            File.Create(_filePath).Dispose();
        }

        else if (File.ReadAllText(_filePath).Length != 0)
        {
            _savedJournals = JsonSerializer.Deserialize<List<Journal>>(File.ReadAllText(_filePath));
        }

        return;
    }
}