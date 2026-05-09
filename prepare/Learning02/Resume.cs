public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public string toString()
    {
        string stringOut = $"Name: {_name}\n";
        stringOut += "Jobs:\n";
        foreach (Job job in _jobs)
        {
            stringOut += job.toString();
        }
        return stringOut;
    }
}