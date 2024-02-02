class ListingActivity : Activity
{
    private readonly List<string> _listPrompts = new()
    {
        "Who are people that you appreciate?"
        ,"What are personal strengths of yours?"
        ,"Who are people that you have helped this week?"
        ,"When have you felt the Holy Ghost this month?"
        ,"Who are some of your personal heroes?"
};
    private readonly Random _rand = new();

    public ListingActivity(string name, string desc) : base(name, desc) {}

    public void Run()
    {
        StartActivity();
        GivePrompt();
        SecondsCountdown(6);
        GetUserList();
        ConcludeActivity();
    }

    private void GivePrompt()
    {
        Console.WriteLine("Take a few seconds to consider the following prompt, then respond by listing as many answers as you can to the prompt: ");
        Console.WriteLine("> " + _listPrompts[_rand.Next(0, _listPrompts.Count)]);
    }

    private void GetUserList()
    {
        var userList = new List<string>();
        DateTime present = DateTime.Now;
        DateTime stopTime = present.AddSeconds(_activityDuration);

        Console.WriteLine("Please list as many answers to the prompt as you can now.");

        while (DateTime.Now < stopTime)
        {
            userList.Add(Console.ReadLine());
            Console.CursorTop--;
            for(int i = 0; i < userList[^1].Length; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft = 0;
        }

        Console.Clear();
        Console.WriteLine($"That's all the time.\nYou answered with {userList.Count} responses.");
    }
}