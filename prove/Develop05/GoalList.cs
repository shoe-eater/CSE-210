class GoalList
{
    private List<Goal> _goals;

    public GoalList(string[] goalStrings)
    // This constructor parses goal data from strings that were saved in a file.
    {
        _goals = new List<Goal>();

        foreach (string goalString in goalStrings)
        {
            string[] goalData = goalString.Split(": ");
            Goal nextGoal;
            
            switch (goalData[0])
            {
                case "Simple":
                nextGoal = new SimpleGoal(goalData[1], int.Parse(goalData[2]));
                if (goalData[3] == "[X]")
                {
                    nextGoal.Record();
                }
                _goals.Add(nextGoal);
                break;

                case "Eternal":
                nextGoal = new EternalGoal(goalData[1], int.Parse(goalData[2]));
                for (int i = 0; i < int.Parse(goalData[3]); i++)
                {
                    nextGoal.Record();
                }
                _goals.Add(nextGoal);
                break;

                case "Checklist":
                int timesCompleted = int.Parse(goalData[3].Split('/')[0]);
                int goalNumber = int.Parse(goalData[3].Split('/')[1]);
                nextGoal = new ChecklistGoal(goalData[1], int.Parse(goalData[2]), goalNumber);
                for (int i = 0; i < timesCompleted; i++)
                {
                    nextGoal.Record();
                }
                _goals.Add(nextGoal);
                break;
            }
        }
    }

    public void NewGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public string ToDisplay()
    {
        string displayOut = "";
        int number = 0;

        foreach (Goal goal in _goals)
        {
            number++;
            displayOut += $"{number}. {goal.ToDisplay()}\n";
        }

        return displayOut;
    }

    public string ToSave()
    {
        string displayOut = "";

        foreach (Goal goal in _goals)
        {
            displayOut += $"{goal.ToSave()}\n";
        }

        return displayOut;
    }

    public void Record(int goalToRecord)
    {
        _goals[goalToRecord].Record();
    }
}