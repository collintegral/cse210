static class ProgramFunctions
{
    public static Player CreateNewPlayer()
    {
        throw new NotImplementedException();
    }

    public static void CreateNewParty()
    {
        Console.Clear();
        Console.WriteLine("What is your party's name?");
        string name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"What is the name of the GM for {name}?");
        string gmName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"What is {gmName}'s password?");
        string gmPassword = Console.ReadLine();

        Gm newGm = new(gmName, gmPassword);
        Party newParty = new(name, newGm);

        Program._parties.Add(newParty);
        JsonHandler.SaveData(Program._parties);
        
        Console.Clear();
        Console.WriteLine($"Party {Program._parties.Last().Name} created successfully, led by {Program._parties.Last().Gm.Username}.\nPress any key to return to main menu.");
        Console.ReadKey(true);
    }

    public static void SelectUser()
    {
        throw new NotImplementedException();
    }
}
