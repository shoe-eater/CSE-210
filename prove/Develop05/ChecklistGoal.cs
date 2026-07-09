class ChecklistGoal : Goal
{
    private int _goalNumber;
    private int _timesCompleted;

    public ChecklistGoal(string description, int points, int goalNumber) : base(description, points)
    {
        _goalNumber = goalNumber;
        _timesCompleted = 0;
    }

    public override void Record()
    {
        if (_timesCompleted < _goalNumber)
        {
            _timesCompleted++;
            Scoreboard scoreboard = Scoreboard.GetInstance();
            scoreboard.AddScore(GetPoints());
            if (_timesCompleted == _goalNumber)
            {
                scoreboard.AddScore(GetPoints() * _goalNumber);
            }
        }
        else
        {
            throw new Exception("Goal already completed.");
        }
    }

    public override string ToDisplay()
    {
        return $"{GetDescription()}: Completed {_timesCompleted}/{_goalNumber} times.";
    }

    public override string ToSave()
    {
        return $"Checklist {GetDescription()}: {GetPoints()}: {_timesCompleted}/{_goalNumber}";
    }
}