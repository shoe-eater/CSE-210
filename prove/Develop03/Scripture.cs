class Scripture
{
    private Reference _sjr_reference;
    private List<Verse> _sjr_verses;

    public Scripture(Reference sjr_reference, List<Verse> sjr_verses)
    {
        _sjr_reference = sjr_reference;
        _sjr_verses = sjr_verses;
    }

    public Scripture(string sjr_scriptureData)
    {
        // Split the data for parsing.
        string[] sjr_splitData = sjr_scriptureData.Split('\n');
        // Read the reference data.
        string sjr_reference = sjr_splitData[0];
        int sjr_lastSpace = sjr_reference.LastIndexOf(' ');
        // The book is everything before the last space on this line.
        string sjr_book = sjr_reference.Substring(0, sjr_lastSpace);
        // The chapter is between the last space and the colon.
        int sjr_chapter = int.Parse(sjr_reference.Split(' ')[^1].Split(':')[0]);
        // The start verse is between the colon and the dash.
        int sjr_startVerse = int.Parse(sjr_reference.Split(':')[^1].Split('-')[0]);
        // The end verse is after the dash, if there is one.
        int sjr_endVerse = sjr_startVerse;
        if (sjr_reference.Contains('-'))
        {
            sjr_endVerse = int.Parse(sjr_reference.Split('-')[^1]);
        }
        // Save the reference.
        _sjr_reference = new Reference(sjr_book, sjr_chapter, sjr_startVerse, sjr_endVerse);
        _sjr_verses = new List<Verse>();
        // For each verse in the data,
        for (int i = 1; i <= sjr_endVerse - sjr_startVerse + 1; i++)
        {
            // Read the next stream of characters and split into words.
            string sjr_nextData = sjr_splitData[i];
            string[] sjr_nextStrings = sjr_nextData.Split(' ');
            List<Word> sjr_nextWords = new List<Word>();
            // Create word classes and append them to the word list.
            foreach (string sjr_nextString in sjr_nextStrings)
            {
                Word sjr_nextWord = new Word(sjr_nextString);
                sjr_nextWords.Add(sjr_nextWord);
            }
            // Create the verse and append it to the scripture.
            Verse sjr_nextVerse = new Verse(sjr_nextWords);
            _sjr_verses.Add(sjr_nextVerse);
        }
    }

    public string toString()
    {
        // Start with the reference.
        string sjr_scriptureOut = _sjr_reference.toString();
        // Add each of the verses to the output string.
        foreach (Verse sjr_verse in _sjr_verses)
        {
            sjr_scriptureOut += '\n' + sjr_verse.toString();
        }
        return sjr_scriptureOut;
    }

    public void hideWords()
    {
        foreach (Verse sjr_verse in _sjr_verses)
        {
            sjr_verse.hideWords();
        }
    }
    
    public bool isHidden()
    {
        // If it gets through the loop, all verses are hidden, but returns false if one isn't.
        foreach (Verse sjr_verse in _sjr_verses)
        {
            if (!sjr_verse.isHidden())
            {
                return false;
            }
        }
        return true;
    }
}