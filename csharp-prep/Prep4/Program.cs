using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Initalize a list and introduce the user.
        List<float> numbers = new List<float>();
        float enteredNumber;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do // Add numbers to a list.
        {
            // Get input from user.
            Console.Write("Enter number: ");
            enteredNumber = float.Parse(Console.ReadLine());

            if (enteredNumber != 0)
            {
                numbers.Add(enteredNumber);
            }
        } while (enteredNumber != 0);

        // Initalize data variables.
        float sum = 0;
        float average = 0;
        float largest = float.MinValue;

        // This loop computes the sum and largest number simultaneously.
        foreach (float number in numbers)
        {
            sum += number;

            if (number > largest)
            {
                largest = number;
            }
        }
        // Average can be computed from sum.
        average = sum / numbers.Count;

        // Print the data.
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}