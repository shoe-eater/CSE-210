using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // This line makes my spinner display instead of being a "?".
        Console.OutputEncoding = Encoding.UTF8;

        bool SJRinMenu = true;

        while (SJRinMenu)
        {
            Console.WriteLine("Menu Options:\n  1. Breathing Activity\n  2. Reflecting Activity\n  3. Listing Activity\n  4. Quit\nSelect a choice from the menu.");
            string SJRresponse = Console.ReadLine();

            switch (SJRresponse)
            {
                case "1":
                    BreathingActivity SJRbreathingActivity = new BreathingActivity();
                    SJRbreathingActivity.DoActivity();
                    break;
                case "2":
                    ReflectingActivity SJRreflectingActivity = new ReflectingActivity();
                    SJRreflectingActivity.DoActivity();
                    break;
                case "3":
                    ListingActivity SJRlistingActivity = new ListingActivity();
                    SJRlistingActivity.DoActivity();
                    break;
                case "4":
                    SJRinMenu = false;
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        Console.Clear();
    }
}