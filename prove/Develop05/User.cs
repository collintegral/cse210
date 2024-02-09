using System.Text.Json.Serialization;

class User
{
    [JsonInclude] public string Username {get; set;}
    [JsonInclude] public int Points {get; set;}
    [JsonInclude] public List<Goal> Goals {get; set;}


    public User()   {}
}