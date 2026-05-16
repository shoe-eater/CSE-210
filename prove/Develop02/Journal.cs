class Journal
{
    string _sjr_name;
    List<Entry> _sjr_entries;

    public Journal(string sjr_name, List<Entry> sjr_entries)
    {
        // Basic constructor.
        _sjr_name = sjr_name;
        _sjr_entries = sjr_entries;
    }

    public Journal(string sjr_name = "")
    {
        // Basic blank constructor.
        _sjr_name = sjr_name;
        _sjr_entries = new List<Entry>();
    }

    public string ToString()
    {
        // Use this to display the journal
        string sjr_output = "";
        foreach (Entry sjr_entry in _sjr_entries)
        {
            sjr_output += sjr_entry.ToString();
        }
        return sjr_output;
    }

    public string ToStringForCsv()
    {
        // Use this for saving the Journal to a text file.
        string sjr_output = "";
        foreach (Entry sjr_entry in _sjr_entries)
        {
            sjr_output += sjr_entry.ToStringForCsv();
        }
        return sjr_output;
    }

    public void LoadFromString(string sjr_journal)
    {
        // Parse a csv string to load a journal. Doesn't
        // actually use commas, uses "~~~" instead.
        // The Split method returns a list of strings
        // from between each specified string or char.
        string[] sjr_string_entries = sjr_journal.Split('\n');
        // Drop last item in the array as it's a null string.
        sjr_string_entries = sjr_string_entries[..^1];
        List<Entry> sjr_entries = new List<Entry>();
        // "For each line in the journal file."
        foreach (string sjr_string_entry in sjr_string_entries)
        {
            // Separate the data by looking for "~~~".
            string[] sjr_data = sjr_string_entry.Split("~~~");
            // Create a new Entry object with the data
            // and put it in entries.
            Entry sjr_entry = new Entry(sjr_data[0], sjr_data[1], sjr_data[2]);
            sjr_entries.Add(sjr_entry);
        }
        // Load the new entries as the working Journal.
        _sjr_entries = sjr_entries;
    }

    public void NewEntry(string sjr_prompt, string sjr_response)
    {
        // This function puts a new entry in the Journal.
        Entry sjr_entry = new Entry(sjr_prompt, sjr_response);
        _sjr_entries.Add(sjr_entry);
    }
}