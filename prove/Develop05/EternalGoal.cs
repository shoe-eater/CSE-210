class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string description, int points) : base(description, points)
    {
        _timesCompleted = 0;
    }

    public override void Record()
    {
        _timesCompleted++;
        Scoreboard scoreboard = Scoreboard.GetInstance();
        scoreboard.AddScore(GetPoints());
    }

    public override string ToDisplay()
    {
        return $"{GetDescription()}: Completed {_timesCompleted} times.";
    }

    public override string ToSave()
    {
        return $"Eternal: {GetDescription()}: {GetPoints()}: {_timesCompleted}";
    }
}