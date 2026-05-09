using System;
using System.Security.Cryptography;
using System.IO; //To load journal files

class Program
{
    static void Main(string[] args)
    {
        //Initialize Journal and while loop
        Journal userJournal = new Journal();
        bool keepRunning = true;

        while (keepRunning == true)
        {
            //Initialize and prompt for input
            int userChoice = 0;
            Console.Write("What would you like to do?\n1. Write a new journal entry\n2. Display the journal\n3. Save my journal to a file\n4. Load my journal from a file\n5. Exit\n(1/2/3/4/5): ");
            try //Basic input validation
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input is not an acceptable option. Please try again.");
            }

            //Process input
            switch (userChoice)
            {
                case 1: //New entry
                    string todaysPrompt = GeneratePrompt(); //Get prompt
                    Console.Write($"{todaysPrompt}\n"); //Display prompt
                    string addEntry = Console.ReadLine(); //Get new entry
                    userJournal.NewEntry(todaysPrompt, addEntry); //Add prompt and entry to journal
                    break;

                case 2: //Print all entries
                    Console.WriteLine(userJournal.ToString());
                    break;

                case 3: //Save to a file
                    string newJournalFile = userJournal.ToStringForCsv(); //Prepare entries for export
                    Console.Write("Please supply the name of to the file you want to write to: "); //Prompt for path
                    string exportJournalPath = Console.ReadLine();
                    try
                    {
                        File.WriteAllText(exportJournalPath, newJournalFile); //Write entries to file
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Invalid Path"); //Break from switch if path isn't valid
                        break;
                    }
                    Console.WriteLine("Journal saved to file."); //Notify user
                    break;

                case 4: //Load from a file
                    string newJournalEntries = userJournal.ToString();
                    Console.Write("Please supply the name of the file you want to load: "); //Prompt for path
                    string newJournalPath = Console.ReadLine();
                    try
                    {
                        newJournalEntries = File.ReadAllText(newJournalPath); //Read file for entries
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Invalid Path"); //Break from switch if path isn't valid
                        break;
                    }
                    try
                    {
                        userJournal.LoadFromString(newJournalEntries); //Load entries into journal
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Error while parsing"); //Unless there is an error while parsing them
                        break;
                    }
                    Console.WriteLine("New journal loaded."); //Notify user
                    break;
                
                case 5: //Exit the program
                    Console.WriteLine("Exiting.");
                    keepRunning = false;
                    break;

                default: //User probably didn't give acceptable input
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }
        
    }

    static string GeneratePrompt()
    {
        string[] prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the best thing that I accomplished today?",
        "What did I do today that will help me tomorrow?",
        "What was something that I learned today?"
    ];
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        return prompt;
    }

}