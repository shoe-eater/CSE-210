using System.Runtime.InteropServices;

public class Job
{
    public string _jobTitle;
    public string _companyName;
    public int _startYear;
    public int _endYear;

    public string toString()
    {
        return $"{_jobTitle} ({_companyName}) {_startYear}-{_endYear}\n";
    }
}