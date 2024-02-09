using System.Numerics;

class Activity
{
    protected string _activityName;
    protected string _activityDescription;
    protected int _activityDuration;

    public Activity(string name, string desc)
    {
        _activityName = name;
        _activityDescription = desc;
        _activityDuration = 0;
    }

    public string GetName()
    {
        return _activityName;
    }

    protected void StartActivity()
    {
        Console.WriteLine($"{_activityName}: {_activityDescription}");
        Console.Write("Please enter in seconds how long you would like to spend on the activity: ");
        _activityDuration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Press any key when you're ready to begin the activity.");
        Console.ReadKey(true);
        Console.Clear();
    }
    protected void ConcludeActivity()
    {
        Console.WriteLine($"You've completed {_activityName}, well done.\nYou spent {_activityDuration} seconds.\nPress any key when you're ready to return to the menu.");
        Console.ReadKey(true);
    }

    public void BreathAnimation()
    {
        DateTime present = DateTime.Now;
        DateTime stopTime = present.AddSeconds(_activityDuration);

        Console.Write("|                            |");
        while (DateTime.Now < stopTime)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("Breathe In... ");
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 16; i++)
            {
                Console.Write(">");
                Thread.Sleep(125);
                if (DateTime.Now > stopTime)    {break;}
            }
           if (DateTime.Now > stopTime)    {break;}
            for (int i = 0; i < 8; i ++)
            {
                Console.Write(">");
                Thread.Sleep(250);
                if (DateTime.Now > stopTime)    {break;}
            }
            if (DateTime.Now > stopTime)    {break;}
            for (int i = 0; i < 4; i ++)
            {
                Console.Write(">");
                Thread.Sleep(500);
                if (DateTime.Now > stopTime)    {break;}
            }
            if (DateTime.Now > stopTime)    {break;}
            Thread.Sleep(2000);
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Breathe Out...");
            Console.SetCursorPosition(29, 0);
            if (DateTime.Now > stopTime)    {break;}
            for (int i = 0; i < 20; i ++)
            {
                Console.Write("\b \b");
                Thread.Sleep(150);
                if (DateTime.Now > stopTime)    {break;}
            }
            if (DateTime.Now > stopTime)    {break;}
            for (int i = 0; i < 8; i ++)
            {
                Console.Write("\b \b");
                Thread.Sleep(125);
                if (DateTime.Now > stopTime)    {break;}
            }
            if (DateTime.Now > stopTime)    {break;}
            Thread.Sleep(2000);
            if (DateTime.Now > stopTime)    {break;}
        }
        Console.Clear();
    }

    public static void SecondsCountdown(int seconds)
    {
        DateTime present = DateTime.Now;
        DateTime stopTime = present.AddSeconds(seconds);

        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
        }
        Console.Write(" ");

        while (DateTime.Now < stopTime)
        {
            Console.Write("\b\b\b ");
            Thread.Sleep(1000);
        }
        Console.CursorLeft = 0;
    }

    public static void SecondsCountdown(int seconds, DateTime endTime)
    {
        DateTime present = DateTime.Now;
        DateTime stopTime = present.AddSeconds(seconds);

        if (endTime < stopTime)
        {
            stopTime = present.AddSeconds((endTime - present).TotalSeconds);
        }

        for (int i = 0; i < (stopTime - present).TotalSeconds; i++)
        {
            Console.Write(". ");
        }
        Console.Write(" ");

        while (DateTime.Now < stopTime)
        {
            Console.Write("\b\b\b ");
            Thread.Sleep(1000);
        }
        Console.CursorLeft = 0;
    }
}