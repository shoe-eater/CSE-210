class Fisherman
{
    private List<Catch> _catches;
    private int _money;
    private Random _random;

    public Fisherman()
    {
        _catches = new List<Catch>();
        _money = 0;
    }

    public Catch GoFishing()
    {
        double catchChance = _random.NextDouble();
        Catch newCatch;
        if (catchChance < 0.7)
        {
            newCatch = new Fish();
        }
        else if (catchChance < 0.9)
        {
            newCatch = new Junk();
        }
        else
        {
            newCatch = new Treasure();
        }
        _catches.Add(newCatch);
        return newCatch;
    }

    public string ListCatches()
    {
        string output = "";
        foreach (Catch item in _catches)
        {
            output += $"{item.GetName(), -30}: {item.GetValue(), 5}g\n";
        }
        return output;
    }

    public string Sell()
    {
        int profit = 0;
        string output = "You sold all your fish and treasure.\n";
        foreach (Catch item in _catches)
        {
            profit += item.GetValue();
        }
        _money += profit;
        output += $"You gained {profit}g. You now have {_money}g.";
        return output;
    }
}