using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the user's name.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Print a message to the user.
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}