class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt = "", string response = "")
    {
        // Contructor accepts a prompt and response, but
        // uses DateTime to get the date automatically.
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToString();
    }

    public Entry(string prompt, string response, string date)
    {
        // This contructor is used for loading a journal
        // from a file.
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public string ToString()
    {
        return $"{_prompt} {_response} {_date}\n";
    }

    public string ToStringForCsv()
    {
        return $"{_prompt}~{_response}~{_date}\n";
    }
}