using System.Runtime.InteropServices;

class Verse
{
    private List<Word> _sjr_words;
    private List<int> _sjr_hideOrder;
    private Random _sjr_random;

    public Verse(List<Word> sjr_words)
    {
        _sjr_words = sjr_words;
        // Learned this line of code from gemini. Creates a sequence of numbers from 0 to word count minus one.
        _sjr_hideOrder = Enumerable.Range(0, _sjr_words.Count).ToList();
        _sjr_random = new Random();

        // Shuffle the order that words are hidden. Also learned from gemini.
        _sjr_random.Shuffle(CollectionsMarshal.AsSpan(_sjr_hideOrder));
    }

    public int GetVerseLength()
    {
        return _sjr_words.Count;
    }

    public string toString()
    {
        string sjr_verseOut = "";
        // Append each word to verseOut.
        foreach (Word sjr_word in _sjr_words)
        {
            sjr_verseOut += sjr_word.toString() + " ";
        }
        // Remove the last space.
        sjr_verseOut = sjr_verseOut.Remove(sjr_verseOut.Length-1);
        return sjr_verseOut;
    }

    public void hideWords()
    {
        int sjr_hideMin = _sjr_words.Count() / 10;
        // Hide up to 16% of the words.
        // For the number of times that was passed into this function,
        for (int i = 0; i < sjr_hideNumber; i++)
        {
            try
            {
                // Hides the word at the next index indicated by the shuffledIndexes array.
                _sjr_words[_sjr_hideOrder[0]].hideWord();
                _sjr_hideOrder.RemoveAt(0);
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
            {
                // Breaks if there are no more words to hide.
                break;
            }
        }
    }

    public bool isHidden()
    {
        // Returns whether the verse is completely hidden.
        return _sjr_hideOrder.Count == 0;
    }
}