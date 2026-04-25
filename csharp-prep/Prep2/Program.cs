using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage.
        Console.Write("What is your grade percentage? ");
        float grade = float.Parse(Console.ReadLine());
        char letter;

        // Determine the letter grade for that percentage.
        if (grade >= 90)
        {
            letter = 'A';
        }
        else if (grade >= 80)
        {
            letter = 'B';
        }
        else if (grade >= 70)
        {
            letter = 'C';
        }
        else if (grade >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Print the grade the user got.
        Console.Write($"You got a {letter}. ");

        // Determine if the user passed.
        if (grade >= 70)
        {
            // Display the results.
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }

        
    }
}