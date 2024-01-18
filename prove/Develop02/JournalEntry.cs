using System.Text.Json.Serialization;

public class JournalEntry
{
    [JsonInclude]public DateOnly _entryDate;
    [JsonInclude]public string _entryPrompt;
    [JsonInclude]public string _entryContent;

    public void SetDate()
    {
        _entryDate = DateOnly.FromDateTime(DateTime.Now);
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_entryDate}\nPrompt: {_entryPrompt}\nEntry: {_entryContent}");
    }
}