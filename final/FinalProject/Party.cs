using System.Text.Json.Serialization;

class Party
{
    public string Name {get; set;}
    public Gm Gm {get; set;}
    public List<Player> Players {get; set;}
    public List<KeyItem> Stash {get; set;}
    

    [JsonConstructor] public Party() {}

    public Party(string name, Gm gm)
    {
        Name = name;
        Gm = gm;
    }
}