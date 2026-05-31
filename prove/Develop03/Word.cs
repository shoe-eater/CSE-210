class Word
{
    private string _sjr_word;
    private string _sjr_blank;
    private bool _sjr_hidden;

    public Word(string sjr_word)
    {
        _sjr_word = sjr_word;
        _sjr_blank = "";
        _sjr_hidden = false;
        char[] sjr_dontHideList = [',', '.', '!', '?', ';', ':', '"', '(', ')', '-'];
        for (int i = 0; i < sjr_word.Length; i++)
        {
            // Skip hiding punctuation. Looked this up on google.
            if (sjr_dontHideList.Contains(_sjr_word[i]))
            {
                _sjr_blank += sjr_word[i];
            }
            else
            {
                _sjr_blank += "_";
            }
        }
    }

    public string toString()
    {
        if (_sjr_hidden)
        {
            return _sjr_blank;
        }
        else
        {
            return _sjr_word;
        }
    }

    public bool isHidden()
    {
        return _sjr_hidden;
    }

    public void hideWord()
    {
        _sjr_hidden = true;
    }
}