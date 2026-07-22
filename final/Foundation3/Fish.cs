class Fish : Catch
{
    private double _weight;
    private Random _random;
    private Dictionary<string, double> _types;

    public Fish()
    {
        _types = new Dictionary<string, double>
        {
            {"bass", 20},
            {"carp", 15},
            {"catfish", 24},
            {"minnow", 8},
            {"red snapper", 16},
            {"salmon", 18},
            {"trout", 12}
        };
        string name = _types.Keys.ToArray()[_random.Next() % _types.Count];
        _weight = _types[name] * (_random.NextDouble() + 1.5) * (_random.NextDouble() + 1.5) / 4;
        int value = (int)Math.Round(_weight * 0.5);
        Initialize(name, value);
    }

    public double GetWeight()
    {
        return _weight;
    }
}