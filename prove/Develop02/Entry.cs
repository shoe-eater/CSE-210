class Entry
{
    private string _sjr_prompt;
    private string _sjr_response;
    private string _sjr_date;

    public Entry(string sjr_prompt = "", string sjr_response = "")
    {
        // Contructor accepts a prompt and response, but
        // uses DateTime to get the date automatically.
        _sjr_prompt = sjr_prompt;
        _sjr_response = sjr_response;
        _sjr_date = DateTime.Now.ToString();
    }

    public Entry(string sjr_prompt, string sjr_response, string sjr_date)
    {
        // This contructor is used for loading a journal
        // from a file.
        _sjr_prompt = sjr_prompt;
        _sjr_response = sjr_response;
        _sjr_date = sjr_date;
    }

    public string ToString()
    {
        // Because this ends with its own newline, anything
        // that prints entries should use Console.Write()
        return $"{_sjr_prompt}\n{_sjr_response}\n{_sjr_date}\n";
    }

    public string ToStringForCsv()
    {
        return $"{_sjr_prompt}~~~{_sjr_response}~~~{_sjr_date}\n";
    }
}