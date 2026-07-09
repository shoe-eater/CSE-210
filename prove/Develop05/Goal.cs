abstract class Goal
{
    private string _description;
    private int _points;

    protected Goal(string description, int points)
    {
        _description = description;
        _points = points;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    public abstract void Record();

    public abstract string ToDisplay();

    public abstract string ToSave();
}