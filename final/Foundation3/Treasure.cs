class Treasure : Catch
{
    private string _rarity;
    private Random _random;
    private Dictionary<string, string[]> _types;

    public Treasure()
    {
        _types = new Dictionary<string, string[]>
        {
            {"uncommon", ["necklace", "jade", "another fishing rod"]},
            {"rare", ["white pearl", "geode", "fossil"]},
            {"epic", ["black pearl", "silver chalice", "purple snail"]},
            {"legendary", ["pink pearl", "golden amulet", "treasure map"]}
        };
        double rarityChance = _random.NextDouble();
        double baseValue;
        if (rarityChance < 0.6)
        {
            _rarity = "uncommon";
            baseValue = 30;
        }
        else if (rarityChance < 0.9)
        {
            _rarity = "rare";
            baseValue = 100;
        }
        else if (rarityChance < 0.98)
        {
            _rarity = "epic";
            baseValue = 300;
        }
        else
        {
            _rarity = "legendary";
            baseValue = 1000;
        }
        string name = _types[_rarity][_random.Next() % _types[_rarity].Length];
        int value = (int)Math.Round(baseValue * (_random.NextDouble() + 1.5) * (_random.NextDouble() + 1.5) / 4);
        Initialize(name, value);
    }

    public string GetRarity()
    {
        return _rarity;
    }
}