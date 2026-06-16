using System.Diagnostics;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        
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
        int SJRtargetTime = 0;
        StartStopwatch();

        while (GetStopwatchTime() <= GetDuration())
        {
            Console.WriteLine("Breathe in...");
            SJRtargetTime += 4000;
            // Calculates the time it should wait in the next spinner. (Zero if the activity is complete)
            int SJRwaitTime = Math.Min(GetDuration(), SJRtargetTime) - GetStopwatchTime();
            Spin(SJRwaitTime / 64 + 1, SJRwaitTime);

            if (GetStopwatchTime() <= GetDuration())
            {
                SJRtargetTime += 6000;
                Console.WriteLine("Breathe out...");
                SJRwaitTime = Math.Min(GetDuration(), SJRtargetTime) - GetStopwatchTime();
                Spin(SJRwaitTime / 64 + 1, SJRwaitTime);
            }
            Console.WriteLine();
        }
    }
}