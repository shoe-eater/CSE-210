using System.Xml;

class Zoo
{
    private Dictionary<Animal, int> _animals;

    public Zoo() // Yes, many zoos are public.
    {
        _animals = new Dictionary<Animal, int> {};
    }

    public void AddAnimal(Animal animal, int count = 1)
    {
        if (_animals.ContainsKey(animal))
        {
            _animals[animal] += count;
        }
        else
        {
            _animals[animal] = count;
        }
        if (_animals[animal] <= 0)
        {
            _animals.Remove(animal);
        }
    }

    private Dictionary<string, float> ComputeTotalRation()
    {
        Dictionary<string, float> rationTotal = new Dictionary<string, float> {};

        foreach (Animal animal in _animals.Keys)
        {
            Dictionary<string, float> ration = animal.GetRation();

            foreach (string diet in ration.Keys)
            {
                if (rationTotal.ContainsKey(diet))
                {
                    rationTotal[diet] += ration[diet] * _animals[animal];
                }
                else
                {
                    rationTotal[diet] = ration[diet] * _animals[animal];
                }
            }
        }

        return rationTotal;
    }

    public string ListAnimals()
    {
        string output = "";
        
        foreach (Animal animal in _animals.Keys)
        {
            output += $"{animal.GetName()}: {_animals[animal]}\n";
        }

        return output;
    }

    public string FeedingTime()
    {
        Dictionary<string, float> rationTotal = ComputeTotalRation();
        string output = "Feeding time!\n\nTotal food eaten:\n";

        foreach (string diet in rationTotal.Keys)
        {
            output += $"{rationTotal[diet]} lbs of {diet}\n";
        }

        return output;
    }
}