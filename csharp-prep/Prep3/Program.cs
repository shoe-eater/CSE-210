using System;
class Program
{
    static void Main(string[] args)
    {
        // Initialize some variables and send a welcome message.
        string response;
        int guessedNumber;
        Random numberGenerator = new Random();
        Console.WriteLine("Welcome to the number guessing game. I'm thinking of a random number from 1 to 100.");

        do // Game loop.
        {
            // These variables need to be reset each game, so they are initalized here.
            int magicNumber = numberGenerator.Next(1, 101);
            int numberOfGuesses = 0;

            do // Guess loop.
            {
                // Ask the user for their guess.
                Console.Write("What is your guess? ");
                guessedNumber = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                // Give feedback based on the guess.
                if (guessedNumber > magicNumber)
                {
                    Console.WriteLine("Lower.");
                }
                else if (guessedNumber < magicNumber)
                {
                    Console.WriteLine("Higher.");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            } while (magicNumber != guessedNumber);

            // Ask if the user would like to play again.
            Console.Write("Would you like to play again? (y/n): ");
            response = Console.ReadLine();
        } while (response == "y");
        Console.WriteLine("Goodbye.");
    }
}