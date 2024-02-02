class BreathingActivity : Activity
{
    public BreathingActivity(string name, string desc) : base(name, desc)   {}

    public void Run()
    {
        StartActivity();
        BreathAnimation();
        ConcludeActivity();
    }
}