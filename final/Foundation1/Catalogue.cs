class Catalogue
{
    private Dictionary<string, Animal> _animals;

    public Catalogue()
    {
        _animals = new Dictionary<string, Animal> {};
    }

    public bool AddAnimal(Animal animal)
    {
        bool replaced = false;
        if (_animals.ContainsKey(animal.GetName()))
        {
            replaced = true;
        }
        _animals[animal.GetName()] = animal;
        return replaced;
    }

    public Animal GetAnimal(string name)
    {
        return _animals[name];
    }

    public string ListAnimals()
    {
        string output = "";

        foreach (Animal animal in _animals.Values)
        {
            output += $"{animal.GetName()}\n";
        }
        return output;
    }

    public string ToSave()
    {
        string output = "";

        foreach (Animal animal in _animals.Values)
        {
            output += $"{animal.ToSave()}\n";
        }
        return output;
    }
}