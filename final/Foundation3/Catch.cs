abstract class Catch
{
    private string _name;
    private int _value;

    protected void Initialize(string name, int value)
    {
        _value = value;
        _name = name;        
    }

    public string GetName()
    {
        return _name;
    }

    public int GetValue()
    {
        return _value;
    }
}