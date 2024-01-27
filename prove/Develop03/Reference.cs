using System.Xml.Schema;

public class ScriptRef
{
    private string _book;
    private string _chapter;
    private string _verses;

    public ScriptRef(string reference)
    {     
        string[] splitRef = reference.Split(":");

        _book = string.Join(" ", splitRef[0].Split(" ")[..^1]);
        _chapter = splitRef[0].Split(" ").Last();
        _verses = splitRef[1];
    }

    public string GetRef()
    {
        return $"{_book} {_chapter}:{_verses}";
    }
    public void PrintRef()
    {
        Console.WriteLine($"{_book} {_chapter}:{_verses}");
    }
}