class Reference
{
    private string _sjr_book;
    private int _sjr_chapter;
    private int _sjr_startVerse;
    private int _sjr_endVerse;

    public Reference(string sjr_book, int sjr_chapter, int sjr_startVerse, int sjr_endVerse)
    {
        _sjr_book = sjr_book;
        _sjr_chapter = sjr_chapter;
        _sjr_startVerse = sjr_startVerse;
        _sjr_endVerse = sjr_endVerse;
    }

    public string toString()
    {
        if (_sjr_startVerse == _sjr_endVerse)
        {
            return $"{_sjr_book} {_sjr_chapter}:{_sjr_startVerse}";
        }
        else
        {
            return $"{_sjr_book} {_sjr_chapter}:{_sjr_startVerse}-{_sjr_endVerse}";
        }
    }
}