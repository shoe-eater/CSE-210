class Junk : Catch
{
    private string _recycleUse;
    private Random _random;
    private Dictionary<string, string> _types;

    public Junk()
    {
        _types = new Dictionary<string, string>
        {
            {"driftwood", "firewood"},
            {"old boot", "leather"},
            {"peice of rope", "a fishing net"},
            {"seaweed", "mulch"},
            {"tin can", "a new fishing hook"},
        };

        string name = _types.Keys.ToArray()[_random.Next() % _types.Count];
        _recycleUse = _types[name];
        Initialize(name, 0);
    }

    public string GetRecycleUse()
    {
        return _recycleUse;
    }
}