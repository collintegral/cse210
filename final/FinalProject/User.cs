using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Gm), typeDiscriminator: "gm")]
[JsonDerivedType(typeof(Player), typeDiscriminator: "player")]

abstract class User
{
    public string Username {get; set;}
    public string Password {get; set;}


    [JsonConstructor] public User() {}
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool CheckPassword()
    {
        bool exit = false;
        string password;
        do
        {
            password = Console.ReadLine();
            if (Password == password)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect password.\n\n1: Try again\n2: Return to user select");
                
                if (Console.ReadLine() != "1")
                {
                    exit = true;
                }
            }
        }
        while (!exit);
        return false;
    }
}