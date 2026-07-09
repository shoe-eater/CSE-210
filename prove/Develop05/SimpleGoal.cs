using System.Runtime.CompilerServices;

class SimpleGoal : Goal
{
    bool _completed;

    public SimpleGoal(string description, int points) : base(description, points)
    {
        _completed = false;
    }

    public override void Record()
    {
        if (!_completed)
        {        
            _completed = true;
            Scoreboard scoreboard = Scoreboard.GetInstance();
            scoreboard.AddScore(GetPoints());
        }
        else
        {
            throw new Exception("Goal already complete.");
        }
    }

    public override string ToDisplay()
    {
        string checkbox = "[ ]";
        if (_completed)
        {
            checkbox = "[X]";
        }

        return $"{GetDescription()}: {checkbox}";
    }

    public override string ToSave()
    {
        string checkbox = "[ ]";
        if (_completed)
        {
            checkbox = "[X]";
        }

        return $"Simple: {GetDescription()}: {GetPoints()}: {checkbox}";
    }
}