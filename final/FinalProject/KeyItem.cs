using System.Text.Json.Serialization;

class KeyItem
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Value {get; set;}
    public bool Identified {get; set;}

    
    [JsonConstructor] public KeyItem() {}
    public KeyItem(string name, string description, int value, bool identified)
    {
        Name = name;
        Description = description;
        Value = value;
        Identified = identified;
    }

    public void SwapItemObfuscation()
    {
        Identified = !Identified;
    }

    public string PrintItem()
    {
        return null;
    }
}