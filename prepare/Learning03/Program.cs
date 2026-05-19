using System;

class Program
{
    static void Main(string[] args)
    {
        // Fraction fraction1 = new Fraction();
        // Fraction fraction2 = new Fraction(6);
        // Fraction fraction3 = new Fraction(6, 7);

        // fraction1.SetDenominator(4);
        // Console.WriteLine(fraction1.GetDenominator());
        // fraction2.SetNumerator(3);
        // Console.WriteLine(fraction2.GetNumerator());

        // Console.WriteLine(fraction1.GetFractionString());
        // Console.WriteLine(fraction1.GetDecimalValue());
        // Console.WriteLine(fraction2.GetFractionString());
        // Console.WriteLine(fraction2.GetDecimalValue());
        // Console.WriteLine(fraction3.GetFractionString());
        // Console.WriteLine(fraction3.GetDecimalValue());

        Fraction randomFraction = new Fraction();
        Random randomNumerator = new Random();
        Random randomDenominator = new Random();

        for (int i = 0; i < 20; i++)
        {
            randomFraction.SetNumerator(randomNumerator.Next());
            randomFraction.SetDenominator(randomDenominator.Next());
            Console.WriteLine(randomFraction.GetFractionString());
            Console.WriteLine(randomFraction.GetDecimalValue());
        }
    }
}