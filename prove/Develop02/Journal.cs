class Journal
{
    string _name;
    List<Entry> _entries;

    public Journal(string name, List<Entry> entries)
    {
        _name = name;
        _entries = entries;
    }

    public Journal(string name = "")
    {
        _name = name;
        _entries = new List<Entry>();
    }

    public string ToString()
    {
        string output = "";
        foreach (Entry entry in _entries)
        {
            output += entry.ToString();
        }
        return output;
    }

    public string ToStringForCsv()
    {
        string output = "";
        foreach (Entry entry in _entries)
        {
            output += entry.ToStringForCsv();
        }
        return output;
    }

    public void LoadFromString(string journal)
    {
        // Parse a csv string to load a journal.
        string[] string_entries = journal.Split('\n');
        List<Entry> entries = new List<Entry>();
        foreach (string string_entry in string_entries)
        {
            string[] data = string_entry.Split('~');
            Entry entry = new Entry(data[0], data[1], data[2]);
            entries.Add(entry);
        }
    }

    public void NewEntry(string prompt, string response)
    {
        Entry entry = new Entry(prompt, response);
        _entries.Add(entry);
    }
}