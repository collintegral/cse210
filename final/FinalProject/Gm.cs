using System.Text.Json.Serialization;

class Gm : User
{
    public List<Npc> ImportantNpcs {get; set;}
    public List<KeyItem> UnassignedItems {get; set;}


    [JsonConstructor] public Gm() {}
    public Gm(string username, string password) : base(username, password) {}



    public void CreateCreature()
    {

    }

    public void UpdateCreature()
    {

    }

    public void CreateItem()
    {

    }

    public void GiveItem()
    {

    }

    public void ReceiveItem()
    {

    }
}