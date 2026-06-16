using System.Diagnostics;

class Activity
{
    private string _name;
    private string _beginMessage;
    private string _endMessage;
    private int _duration;
    private string _spinner;
    // Looked up time keeping methods on Google and found the Stopwatch class.
    private Stopwatch _stopwatch;
    private Stopwatch _spinStopwatch;

    protected Activity(string name, string description)
    {
        _name = name;
        _beginMessage = $"Welcome to the {name} activity.\n\n{description}\n\nHow long, in seconds, would you like for this session? ";
        _endMessage = $"Well done!!\n\nYou have completed 30 seconds of the {name} activity.";
        _duration = 30000;
        _spinner = "⡀⡄⡆⡇⡏⡟⡿⣿⢿⢻⢹⢸⢰⢠⢀ ";
        _stopwatch = new Stopwatch();
        _spinStopwatch = new Stopwatch();
    }

    protected void PrintBeginMessage()
    {
        Console.Write(_beginMessage);
        _duration = int.Parse(Console.ReadLine()) * 1000;
        _endMessage = $"Well done!!\n\nYou have completed {_duration / 1000} seconds of the {_name} activity.";
        Console.WriteLine("\nGet ready...");
        Spin(48, 3000);
        Console.WriteLine();
    }

    protected void PrintEndMessage()
    {
        Console.WriteLine(_endMessage);
        Spin(80, 5000);
    }
    
    protected int GetDuration()
    {
        return _duration;
    }

    protected void StartStopwatch()
    {
        _stopwatch.Restart();
    }

    protected int GetStopwatchTime()
    {
        return (int)_stopwatch.ElapsedMilliseconds;
    }

    protected void Spin(int SJRticks, int SJRtotalTime)
    {
        // Ticks the spinner a number of times in a number of milliseconds.
        _spinStopwatch.Restart();

        Console.Write(" ");

        // The spinner spins once per second.
        for (int i = 0; i < SJRticks; i++)
        {
            Console.Write("\b" + _spinner[i % _spinner.Length]);
            // Sleep for a fraction of the totalTime.
            Thread.Sleep(Math.Max(SJRtotalTime * (i + 1) / SJRticks - (int)_spinStopwatch.ElapsedMilliseconds, 0));
        }
        
        Console.Write("\b \b");
    }
}