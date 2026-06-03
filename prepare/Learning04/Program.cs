using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("Scott Raber", "Calculus");
        Console.WriteLine(myAssignment.GetSummary());

        MathAssignment myMathAssignment = new MathAssignment("Scott Raber", "Introduction to Analysis", "1.7", "1-3;8");
        Console.WriteLine(myMathAssignment.GetHomeworkList());

        WritingAssignment myWritingAssignment = new WritingAssignment("Scott Raber", "Creative Writing", "Tales of Soris");
        Console.WriteLine(myWritingAssignment.GetWritingInformation());
    }
}