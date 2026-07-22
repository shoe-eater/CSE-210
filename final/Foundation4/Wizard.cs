class Wizard : Fighter
{
    public Wizard() : base(100, 5, 5) {}

    protected override void Attack(Fighter target)
    {
        foreach (Fighter enemy in _enemies)
        {
            base.Attack(target);
        }

        target._moves["Attack"] += Electrified;
        target.AddPassive(RemoveElectrified, 1);
    }

    protected override void Support(Fighter target)
    {
        foreach (Fighter ally in _allies)
        {
            int heal = (int)Math.Round(3 * (_random.NextSingle() + 1.5) / 2);
            ally.ChangeHealth(heal);
        }
    }

    protected override void Special(Fighter target)
    {
        base.Special(target);
        for (int i = 0; i < 3; i++)
        {
            int damage = (int)Math.Round(GetStrength() * (_random.NextSingle() + 1.5) / 2);
            target.ChangeHealth(-damage);
            ChangeHealth(damage);
        }
    }

    private void Electrified(Fighter target)
    {
        int damage = (int)Math.Round(2.5 * (_random.NextSingle() + 1.5) / 2);
        ChangeHealth(-damage);
    }

    private void RemoveElectrified()
    {
        _moves["Attack"] -= Electrified;
        _passives.Remove(RemoveElectrified);
    }
}