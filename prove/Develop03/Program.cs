using System.IO;

class Program
{
    static void Main(string[] args)
    {
        char[] sjr_choiceList = ['o', 'n'];
        char sjr_choice = ' ';
        // Get choice until a valid choice is picked.
        while (!sjr_choiceList.Contains(sjr_choice))
        {
            Console.Write("Welcome to the scripture memorizer program.\nWould you like to open a scripture file (o) or create a new scripture file (n)? ");
            sjr_choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (!sjr_choiceList.Contains(sjr_choice))
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        if (sjr_choice == 'o')
        {
            Scripture sjr_scripture = OpenScripture();
            if (sjr_scripture is Scripture)
            {
                Memorize(sjr_scripture);
            }
        }
        else
        {
            NewScripture();
        }
    }

    static Scripture OpenScripture()
    {
        Console.Write("Please enter the file containing the scripture data: ");
        string sjr_file = Console.ReadLine();
        try
        {
            string sjr_scriptureData = File.ReadAllText(sjr_file);
            Scripture sjr_scripture = new Scripture(sjr_scriptureData);
            return sjr_scripture;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Could not find file \"{sjr_file}\"");
        }
        return null;
    }

    static void Memorize(Scripture sjr_scripture)
    {
        string sjr_quit = "";
        while (!sjr_scripture.isHidden() && sjr_quit != "quit")
        {
            Console.Clear();
            Console.WriteLine(sjr_scripture.toString());
            Console.Write("Press enter to hide more words, or type \"quit\" to quit: ");
            sjr_quit = Console.ReadLine();
            sjr_scripture.hideWords();
        }
        Console.Clear();
        if (sjr_quit != "quit")
        {
            Console.WriteLine(sjr_scripture.toString());
        }
    }

    static void NewScripture()
    {
        // Get the reference information.
        Console.Write("Enter the scripture reference: ");
        string sjr_referenceString = Console.ReadLine();
        int sjr_lastSpace = sjr_referenceString.LastIndexOf(' ');
        // The book is everything before the last space on this line.
        string sjr_book = sjr_referenceString.Substring(0, sjr_lastSpace);
        // The chapter is between the last space and the colon.
        int sjr_chapter = int.Parse(sjr_referenceString.Split(' ')[^1].Split(':')[0]);
        // The start verse is between the colon and the dash.
        int sjr_startVerse = int.Parse(sjr_referenceString.Split(':')[^1].Split('-')[0]);
        // The end verse is after the dash, if there is one.
        int sjr_endVerse = sjr_startVerse;
        if (sjr_referenceString.Contains('-'))
        {
            sjr_endVerse = int.Parse(sjr_referenceString.Split('-')[^1]);
        }
        Reference sjr_reference = new Reference(sjr_book, sjr_chapter, sjr_startVerse, sjr_endVerse);

        List<Verse> sjr_verses = new List<Verse>();
        // For each verse as specified by startVerse and endVerse,
        for (int i = sjr_startVerse; i <= sjr_endVerse; i++)
        {
            // get the text of the verse.
            Console.WriteLine($"Enter the text of verse {i}:");
            string[] sjr_texts = Console.ReadLine().Split(' ');
            List<Word> sjr_words = new List<Word>();
            // For each word in the verse,
            foreach (string sjr_text in sjr_texts)
            {
                // Create a word class and append it to the list of Words.
                Word sjr_word = new Word(sjr_text);
                sjr_words.Add(sjr_word);
            }
            // Create a verse and append it to the list of Verses.
            Verse sjr_verse = new Verse(sjr_words);
            sjr_verses.Add(sjr_verse);

        }
        // Create the Scripture.
        Scripture sjr_scripture = new Scripture(sjr_reference, sjr_verses);
        string sjr_scriptureData = sjr_scripture.toString();
        // Save the scripture data file.
        Console.Write("Enter a file name to save this scripture: ");
        string sjr_file = Console.ReadLine();
        File.WriteAllText(sjr_file, sjr_scriptureData);
    }
}