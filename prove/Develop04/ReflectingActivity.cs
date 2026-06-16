class ReflectingActivity : Activity
{
    private string[] _prompts;
    private string[] _questions;
    private Random _random;
    public ReflectingActivity() : base("reflecting", "This activity will help you reflect on times in your life when you showed strenth and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];
        _questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
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
        Console.Write($"Cosider the following prompt:\n\n{SJRrandomPrompt}\n\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();

        int SJRtargetTime = 0;
        StartStopwatch();

        while (GetStopwatchTime() <= GetDuration())
        {
            Console.WriteLine(_questions[_random.Next(_questions.Length)]);
            SJRtargetTime += 15000;
            // Calculates the time it should wait in the next spinner. (Zero if the activity is complete)
            int SJRwaitTime = Math.Min(GetDuration(), SJRtargetTime) - GetStopwatchTime();
            Spin(SJRwaitTime / 64 + 1, SJRwaitTime);
        }
        Console.WriteLine();
    }
}