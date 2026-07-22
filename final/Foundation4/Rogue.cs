class Rogue : Fighter
{
    public Rogue() : base(70, 6, 4) {}

    protected override void Attack(Fighter target)
    {
        base.Attack(target);
        target.AddPassive(Poison, 3);
    }

    protected override void Support(Fighter target)
    {
        target.AddPassive(Poison, 4);
        target.ChangeStrength(-3);
        target.AddPassive(RegainStrength, 3);
    }

    protected override void Special(Fighter target)
    {
        base.Special(target);
        base.Attack(target);
        base.Attack(target);
        target.ChangeStrength(-2);
    }

    private void Poison()
    {
        ChangeHealth(-_passives[Poison]);
        _passives[Poison]--;
        if (_passives[Poison] == 0)
        {
            _passives.Remove(Poison);
        }
    }

    private void RegainStrength()
    {
        ChangeStrength(_passives[RegainStrength]);
        _passives.Remove(RegainStrength);
    }
}