using System.Text.Json.Serialization;

public class Journal
{
    [JsonInclude]public string _journalName = "";
    [JsonInclude]public List<JournalEntry> _journalEntries = new List<JournalEntry>();

    public void AddEntry(string prompt, string content)
    {
        JournalEntry newEntry = new JournalEntry();
        newEntry.SetDate();
        newEntry._entryPrompt = prompt;
        newEntry._entryContent = content;

        _journalEntries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (JournalEntry entry in _journalEntries)
        {
            Console.Clear();
                entry.DisplayEntry();
                if (entry.Equals(_journalEntries.Last()))
                {
                    Console.WriteLine("This is the last journal entry. Press any key to return to main menu.");
                }
                else
                {
                    Console.WriteLine("Press any key for the next entry, or hit Esc to return to main menu.");
                }

            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}