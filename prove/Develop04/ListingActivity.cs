class ListingActivity : Activity
{
    private string[] _prompts;
    private Random _random;

    public ListingActivity() : base("listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
        _random = new Random();
    }

    public void DoActivity()
    {
        Console.Clear();
        PrintBeginMessage();
        Console.Clear();
        PrintActivityMessage();
        PrintEndMessage();
        Console.Clear();
    }

    private void PrintActivityMessage()
    {
        string SJRrandomPrompt = _prompts[_random.Next(_prompts.Length-1)];
        Console.WriteLine($"List as many responses as you can to the following prompt:\n{SJRrandomPrompt}");
        Spin(80, 5000);
        
        int SJRlistedItems = 0;
        StartStopwatch();

        while (GetDuration() > GetStopwatchTime())
        {
            Console.ReadLine();
            SJRlistedItems++;
        }

        Console.WriteLine($"You listed {SJRlistedItems} items!\n");
    }
}