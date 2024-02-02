class ReflectionActivity : Activity
{
    private readonly List<string> _reflectionPrompts = new()
    { 
        "Think of a time when you stood up for someone else."
        ,"Think of a time when you did something really difficult."
        ,"Think of a time when you helped someone in need."
        ,"Think of a time when you did something truly selfless."
    };
    private readonly List<string> _reflectionQuestions = new()
    {
        "Why was this experience meaningful to you?"
        ,"Have you ever done anything like this before?"
        ,"How did you get started?"
        ,"How did you feel when it was complete?"
        ,"What made this time different than other times when you were not as successful?"
        ,"What is your favorite thing about this experience?"
        ,"What could you learn from this experience that applies to other situations?"
        ,"What did you learn about yourself through this experience?"
        ,"How can you keep this experience in mind in the future?"
    };
    private readonly Random _rand = new();

    public ReflectionActivity(string name, string desc) : base(name, desc)  {}

    public void Run()
    {
        StartActivity();
        GivePrompt();
        SecondsCountdown(6);
        GiveQuestions();
        ConcludeActivity();
    }

    private void GivePrompt()
    {
        Console.WriteLine("Take a few seconds to consider the following prompt: ");
        Console.WriteLine("> " + _reflectionPrompts[_rand.Next(0, _reflectionPrompts.Count)]);
    }

    private void GiveQuestions()
    {
        List<int> randomQuestion = Enumerable.Range(0,_reflectionQuestions.Count).ToList();


        Console.WriteLine("Take several seconds to reflect on the following series of questions as they appear for the duration of the activity: ");

        DateTime present = DateTime.Now;
        DateTime stopTime = present.AddSeconds(_activityDuration);

         while (DateTime.Now < stopTime)
        {
            if (randomQuestion.Count <= 0)
            {
                randomQuestion = Enumerable.Range(0,_reflectionQuestions.Count).ToList();
            }

            int randomQuestionIndex = _rand.Next(0, randomQuestion.Count);
            int nextQ = randomQuestion[randomQuestionIndex];
            randomQuestion.RemoveAt(randomQuestionIndex);

            Console.WriteLine("> " + _reflectionQuestions[nextQ]);

            SecondsCountdown(10, stopTime);
        }

        
    }
}