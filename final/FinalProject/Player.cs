using System.Text.Json.Serialization;

class Player : User
{
    public Hero PlayerCharacter {get; set;}


    [JsonConstructor] public Player() {}
    public Player(string username, string password) : base(username, password) {}


    public void CreateCharacter()
    {

    }

    public void UpdateCharacter()
    {

    }
}