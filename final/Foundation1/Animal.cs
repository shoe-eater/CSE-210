class Animal
{
    private string _name;
    private Dictionary<string, float> _dailyRation;

    public Animal(string name, Dictionary<string, float> dailyRation)
    {
        _name = name;
        _dailyRation = dailyRation;
    }

    public string GetName()
    {
        return _name;
    }

    public Dictionary<string, float> GetRation()
    {
        return _dailyRation;
    }

    public string ToSave()
    {
        string output = $"{_name}: ";

        foreach (string food in _dailyRation.Keys)
        {
            output += $"{food}, {_dailyRation[food]}; ";
        }

        output = output.Remove(output.Length - 2);

        return output;
    }
}