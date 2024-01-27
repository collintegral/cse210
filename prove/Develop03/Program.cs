using System;

class Program
{
    static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "scriptures.txt");
    static readonly List<Scripture> scripturesList = ConstructScriptures();
    static readonly Random random = new Random();

    static void Main(string[] args)
    {
        string userInput = "";
        do
        {
            Console.Clear();
            int optionCount = 1;
            foreach(Scripture script in scripturesList)
            {
                Console.WriteLine($"{optionCount}: {script.GetRef()}");
                optionCount++;
            }
            Console.Write("Select a scripture from the list using the numbers, or type \"exit\": ");
            userInput = Console.ReadLine();

            try 
            {
                if (int.Parse(userInput) <= scripturesList.Count && int.Parse(userInput) > 0)
                {
                    userInput = PracticeScripture(int.Parse(userInput) - 1);
                }
                else
                {
                    Console.WriteLine("Please enter a valid response. A number from the above list, or \"exit\".");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                }
            }
            catch (Exception)
            {
                if (userInput.ToLower() != "exit")
                {
                    Console.WriteLine("Please enter a valid response. A number from the above list, or \"exit\".");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                }
            }
        }
        while (userInput.ToLower() != "exit");

    }

    static string PracticeScripture(int listIndex)
    {
        Scripture currentScript = scripturesList[listIndex];
        string userInput = "";
        bool allHidden = false;
        do
        {
            Console.Clear();
            Console.WriteLine("At any time, type \"menu\" to return to the main menu, or \"exit\" to quit the program.\n");

            currentScript.PrintScripture();
            Console.WriteLine("Hit enter to hide a few words.");
            userInput = Console.ReadLine();
            allHidden = currentScript.HideWords(random);
        }
        while (!allHidden && userInput.ToLower() != "exit" && userInput.ToLower() != "menu");

        if (allHidden)
        {
            Console.Clear();
            currentScript.PrintScripture();
            Console.WriteLine("Well done, that's all the words! Hit any key to return to the main menu.");
            Console.ReadKey(true);
        }

        currentScript.RevealAllWords();
        return userInput;
    }

    static List<Scripture> ConstructScriptures()
        {
            List<Scripture> scripturesList = new List<Scripture>();
            string reference = "";
            bool referenceGet = true;
            List<string> verses = new List<string>();
            Scripture newScript;

            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    newScript = new Scripture(reference, verses);
                    scripturesList.Add(newScript);
                    referenceGet = true;
                    verses.Clear();
                }
                else if (referenceGet)
                {
                    reference = line;
                    referenceGet = false;
                }
                else
                {   
                    verses.Add(line);
                }
            }
            newScript = new Scripture(reference, verses);
            scripturesList.Add(newScript);

            return scripturesList;
        }
}