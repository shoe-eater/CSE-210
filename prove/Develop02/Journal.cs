class Journal
{
    string _name;
    List<Entry> _entries;

    public Journal(string name, List<Entry> entries)
    {
        // Basic constructor.
        _name = name;
        _entries = entries;
    }

    public Journal(string name = "")
    {
        // Basic blank constructor.
        _name = name;
        _entries = new List<Entry>();
    }

    public string ToString()
    {
        // Use this to display the journal
        string output = "";
        foreach (Entry entry in _entries)
        {
            output += entry.ToString();
        }
        return output;
    }

    public string ToStringForCsv()
    {
        // Use this for saving the Journal to a text file.
        string output = "";
        foreach (Entry entry in _entries)
        {
            output += entry.ToStringForCsv();
        }
        return output;
    }

    public void LoadFromString(string journal)
    {
        // Parse a csv string to load a journal. Doesn't
        // actually use commas, uses "~" instead.
        // The Split method returns a list of strings
        // from between each specified character.
        string[] string_entries = journal.Split('\n');
        // Drop last item in array as it's a null string
        string_entries = string_entries[..^1];
        List<Entry> entries = new List<Entry>();
        // "For each line in the journal file."
        foreach (string string_entry in string_entries)
        {
            // Separate the data with the "~" character.
            string[] data = string_entry.Split('~');
            // Create a new Entry object with the data
            // and put it in entries.
            Entry entry = new Entry(data[0], data[1], data[2]);
            entries.Add(entry);
        }
        // Load the new entries as the working Journal.
        _entries = entries;
    }

    public void NewEntry(string prompt, string response)
    {
        // This function puts a new entry in the Journal.
        Entry entry = new Entry(prompt, response);
        _entries.Add(entry);
    }
}