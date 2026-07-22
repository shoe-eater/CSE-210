abstract class Fighter
{
    private int _maxHealth;
    private int _health;
    private double _strength;
    private int _specialRecharge;
    private int _specialCharge;
    public Dictionary<string, Action<Fighter>> _moves;
    protected List<Fighter> _enemies;
    protected List<Fighter> _allies;
    protected Dictionary<Action, int> _passives;
    protected Random _random;
    
    public Fighter(int maxHealth, double strength, int specialRecharge)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
        _strength = strength;
        _specialRecharge = specialRecharge;
        _specialCharge = specialRecharge / 2;
        _moves = new Dictionary<string, Action<Fighter>>
        {
            {"Attack", Attack},
            {"Support", Support},
            {"Special", Special}
        };
        _enemies = new List<Fighter>();
        _allies = new List<Fighter>();
        _passives = new Dictionary<Action, int>{};
        _random = new Random();
    }

    protected virtual void Attack(Fighter target)
    {
        int damage = (int)Math.Round(_strength * (_random.NextSingle() + 1.5) / 2);
        if (damage < 0)
        {
            damage = 0;
        }
        target.ChangeHealth(-damage);
    }

    protected abstract void Support(Fighter target);
    
    protected virtual void Special(Fighter target)
    {
        _specialCharge = 0;
    }

    public void ChangeHealth(int amount)
    {
        if (_health != 0)
        {
            _health += amount;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    public int GetHealth()
    {
        return _health;
    }

    public void ChangeStrength(double amount)
    {
        _strength += amount;
    }

    protected double GetStrength()
    {
        return _strength;
    }

    public bool SpecialReady()
    {
        return _specialCharge >= _specialRecharge;
    }

    public void AddPassive(Action passive, int stacks)
    {
        if (_passives.ContainsKey(passive))
        {
            _passives[passive] += stacks;
        }
        else
        {
            _passives[passive] = stacks;
        }
    }

    public void TurnEnd()
    {
        foreach (Action passive in _passives.Keys)
        {
            passive();
        }
        _specialCharge++;
    }
}