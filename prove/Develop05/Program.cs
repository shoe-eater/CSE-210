using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        bool stayInLoop = true;
        GoalList goalList = null;

        // Prompt user to load list or make a new list.
        while (stayInLoop)
        {
            Console.Clear();
            Console.Write("Welcome.\n\nWould you like to load a list of goals, (l) or create a new one? (n): ");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                // Load a list from a file.
                case 'l':
                stayInLoop = false;
                Console.WriteLine("Enter the name of the file to load:");
                string fileName = Console.ReadLine();
                string[] fileData = File.ReadAllLines(fileName);
                goalList = new GoalList(fileData);
                break;

                // Create a new list.
                case 'n':
                stayInLoop = false;
                goalList = new GoalList([]);
                break;

                // Invalid input, try again.
                default:
                Console.WriteLine("Invalid input.");
                break;
            }
        }

        stayInLoop = true;

        // This loop handles the goal menu.
        while (stayInLoop)
        {
            Console.Clear();
            Console.WriteLine("Enter your option:\n1. Create a new simple goal.\n2. Create a new eternal goal.\n3. Create a new checklist goal.\n4. Record an achieved goal.\n5. Display points and goals.\n6. Save and exit.");
            string option = Console.ReadLine();
            Console.Clear();

            string description;
            int points;
            int goalNumber;
            Scoreboard scoreboard = Scoreboard.GetInstance();

            switch (option)
            {
                // New simple goal
                case "1":
                Console.WriteLine("Enter your goal:");
                description = Console.ReadLine();
                Console.Write("Enter the point value of this goal: ");
                points = int.Parse(Console.ReadLine());
                goalList.NewGoal(new SimpleGoal(description, points));
                break;

                // New eternal goal
                case "2":
                Console.WriteLine("Enter your goal:");
                description = Console.ReadLine();
                Console.Write("Enter the point value of this goal: ");
                points = int.Parse(Console.ReadLine());
                goalList.NewGoal(new EternalGoal(description, points));
                break;

                // New checklist goal
                case "3":
                Console.WriteLine("Enter your goal:");
                description = Console.ReadLine();
                Console.Write("Enter the point value of this goal: ");
                points = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of times this goal should be completed: ");
                goalNumber = int.Parse(Console.ReadLine());
                goalList.NewGoal(new ChecklistGoal(description, points, goalNumber));
                break;

                // Record goal
                case "4":
                Console.WriteLine(goalList.ToDisplay());
                Console.Write("Enter the number of the goal you wish to record: ");
                int goalToRecord = int.Parse(Console.ReadLine()) - 1;
                goalList.Record(goalToRecord);
                break;

                // Display goal list
                case "5":
                Console.WriteLine("Total Points: " + scoreboard.GetScore().ToString());
                Console.WriteLine(goalList.ToDisplay());
                Console.Write("Press enter to return to the menu.");
                Console.ReadLine();
                break;

                // Save and exit
                case "6":
                stayInLoop = false;
                Console.Write("Enter the name of the file to save this list of goals: ");
                string fileName = Console.ReadLine();
                File.WriteAllText(fileName, goalList.ToSave());
                Console.Write("File saved. Goodbye.");
                break;
            }
        }
    }
}