using System;

class Program
{
    static void Main(string[] args)
    {
        // The beginning of the program handles loading a saved zoo from a file, or creating a new one.
        Console.Write("Enter the file containing the animal catalogue, or press enter with no input to create a new, emtpy catalogue and zoo: ");
        string catalogueFileName = Console.ReadLine();
        Catalogue catalogue = new Catalogue();
        string zooFileName = "";
        Zoo zoo = new Zoo();

        // If there is an error loading the files, the program continues with new, empty ones.
        if (catalogueFileName != "")
        {
            Console.Clear();
            catalogue = LoadCatalogue(catalogueFileName);

            Console.Write("Enter the file containing the zoo's information, or press enter with no input to create a new, empty zoo: ");
            zooFileName = Console.ReadLine();
            
            if (zooFileName != "")
            {
                Console.Clear();
                zoo = LoadZoo(zooFileName, catalogue);
            }
        }

        Console.Clear();
        bool stayInMainLoop = true;

        // Main menu loop
        while (stayInMainLoop)
        {
            Console.WriteLine("Select an option:\n1: Add an animal to the catalogue.\n2: Add an animal to the zoo.\n3: List the animals in the zoo.\n4: Feed all the animals.\n5: Save and exit.");
            char option = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (option)
            {
                case '1':
                    AddToCatalogue(catalogue);
                    break;

                case '2':
                    AddToZoo(zoo, catalogue);
                    break;

                case '3':
                    Console.WriteLine(zoo.ListAnimals());
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case '4':
                    Console.WriteLine(zoo.FeedingTime());
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                
                case '5':
                    Console.Write("Enter a file name to save the catalogue: ");
                    catalogueFileName = Console.ReadLine();
                    File.WriteAllText(catalogueFileName, catalogue.ToSave());
                    Console.Clear();
                    Console.Write("Enter a file name to save the zoo: ");
                    zooFileName = Console.ReadLine();
                    File.WriteAllText(zooFileName, zoo.ListAnimals());
                    Console.Clear();
                    Console.Write("Files saved!");
                    stayInMainLoop = false;
                    break;

                default:
                    Console.Write("Invalid input. ");
                    break;
            }
        }
    }

    static private Catalogue LoadCatalogue(string catalogueFileName)
    {
        // All the catalogue data in the file is parsed in this function.

        Catalogue catalogue = new Catalogue {};

        try
        {
            string[] catalogueData = File.ReadAllLines(catalogueFileName);
            foreach (string animalData in catalogueData)
            {
                string name = animalData.Split(": ")[0];
                string[] rationData = animalData.Split(": ")[1].Split("; ");
                Dictionary<string, float> rations = new Dictionary<string, float> {};
                foreach (string ration in rationData)
                {
                    string diet = ration.Split(", ")[0];
                    float lbs = float.Parse(ration.Split(", ")[1]);
                    rations[diet] = lbs;
                }
                catalogue.AddAnimal(new Animal(name, rations));
            }

            Console.WriteLine("Catalogue successfully created.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return catalogue;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Continuing with empty catalogue and zoo.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return new Catalogue();
        }
        catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
        {
            Console.WriteLine("The file could not be parsed. Continuing with empty catalogue and zoo.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return new Catalogue();
        }
    }

    static private Zoo LoadZoo(string zooFileName, Catalogue catalogue)
    {
        // All the zoo data in the file is parsed in this function.

        Zoo zoo = new Zoo();

        try
        {
            string[] zooData = File.ReadAllLines(zooFileName);
            foreach (string animalData in zooData)
            {
                string name = animalData.Split(": ")[0];
                Animal animal = catalogue.GetAnimal(name);
                int count = int.Parse(animalData.Split(": ")[1]);
                
                zoo.AddAnimal(animal, count);
            }

            Console.WriteLine("Zoo successfully created.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return zoo;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Continuing with empty zoo.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return new Zoo();
        }
        catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
        {
            Console.WriteLine("The file could not be parsed. Continuing with empty zoo.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return new Zoo();
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("The zoo contains animals that are not in the catalogue. Continuing with empty zoo.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return new Zoo();
        }
    }

    static private void AddToCatalogue(Catalogue catalogue)
    {
        Console.Write("Enter the name of the animal: ");
        string name = Console.ReadLine();
        Console.Clear();
        bool stayInDietLoop = true;
        string food = "";
        Dictionary<string, float> ration = new Dictionary<string, float> {};

        // Uses a loop to get the animal's diet.
        while (stayInDietLoop)
        {
            Console.Write($"Enter something that a {name} eats: ");
            food = Console.ReadLine();
            if (food == "")
            {
                Console.Clear();
                Console.WriteLine($"A {name} must eat something.");
            }
            else
            {
                stayInDietLoop = false;
            }
        }

        stayInDietLoop = true;
        while (stayInDietLoop)
        {
            Console.Write($"Enter the number of pounds of {food} a {name} eats in a day: ");
            float lbs = float.Parse(Console.ReadLine());
            Console.Clear();

            ration[food] = lbs;

            Console.Write($"Enter something else that a {name} eats, or press enter with no input if done: ");
            food = Console.ReadLine();
            if (food == "")
            {
                stayInDietLoop = false;
            }
        }
        
        Console.Clear();
        // Add animal returns whether it replaced animal data or not.
        bool replaced = catalogue.AddAnimal(new Animal(name, ration));

        if (replaced)
        {
            Console.WriteLine($"{name} updated in catalogue. (You will need to reload the program for changes to take effect.)\nPress any key to continue.");
        }
        else
        {
            Console.WriteLine($"{name} added to catalogue.\nPress any key to continue.");
        }
        Console.ReadKey();
        Console.Clear();
    }

    static private void AddToZoo(Zoo zoo, Catalogue catalogue)
    {
        Console.WriteLine("Enter the name of an animal from the catalogue:");
        Console.WriteLine(catalogue.ListAnimals());
        string name = Console.ReadLine();
        Animal animal = null;
        Console.Clear();
        try
        {
            animal = catalogue.GetAnimal(name);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("That animal is not in the catalogue.\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.Write($"Enter the number of this animal being added (negative numbers remove animals): ");
        int count = int.Parse(Console.ReadLine());
        Console.Clear();
        
        zoo.AddAnimal(animal, count);
    }
}