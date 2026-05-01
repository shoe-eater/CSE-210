using System;

class Program
{
    static void DisplayWelcome()
    /* Welcomes the user. */
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    /* Gets and returns the user's name as input. */
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    /* Gets and returns the user's favorite number as input. */
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }

    static int PromptUserBirthYear()
    /* Gets and returns the user's birth year as input. */
    {
        Console.Write("Please enter the year you were born: ");
        int birthYear = int.Parse(Console.ReadLine());
        return birthYear;
    }

    static int SquareNumber(int x)
    /* Returns the parameter number squared. */
    {
        int xSquared = x * x;
        return xSquared;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    /* Displays all the data collected. */
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        Console.WriteLine($"{name}, you will turn {2026 - birthYear} this year.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int birthYear = PromptUserBirthYear();
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(name, squaredNumber, birthYear);
    }
}