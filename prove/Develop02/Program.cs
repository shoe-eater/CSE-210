using System;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.IO.Enumeration;
using System.Runtime.CompilerServices; //To load journal files

class Program
{
    static void Main(string[] args)
    {
        Journal sjr_workingJournal = new Journal();
        bool sjr_run = true;
        bool unsaved_progress = false;

        // While loop keeps the user coming back to the main menu.
        while (sjr_run)
        {
            Console.Write("Enter your option (press \"o\" for options): ");
            char sjr_input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (sjr_input)
            {
                case 'w':
                    WriteNewEntry(sjr_workingJournal);
                    unsaved_progress = true;
                    break;
                case 'd':
                    DisplayJournal(sjr_workingJournal);
                    break;
                case 's':
                    SaveJournal(sjr_workingJournal);
                    unsaved_progress = false;
                    break;
                case 'l':
                    LoadJournal(sjr_workingJournal);
                    break;
                case 'o':
                    Console.WriteLine("Options:\nw: Write new entry.\nd: Display journal.\ns: Save journal.\nl: Load journal.\no: Display this menu.\nx: Exit the program.");
                    break;
                case 'x':
                    if (ConfirmAction(unsaved_progress))
                    {
                        sjr_run = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        static void WriteNewEntry(Journal sjr_journal)
        {
            string sjr_prompt = GeneratePrompt();
            Console.WriteLine(sjr_prompt);
            string sjr_response = Console.ReadLine();
            sjr_journal.NewEntry(sjr_prompt, sjr_response);
        }

        static void DisplayJournal(Journal sjr_journal)
        {
            Console.Write(sjr_journal.ToString());
        }

        static void SaveJournal(Journal sjr_journal)
        {
            Console.WriteLine("Write the name of the file to save this journal to:");
            string sjr_filename = Console.ReadLine();
            File.WriteAllText(sjr_filename, sjr_journal.ToStringForCsv());
        }

        static void LoadJournal(Journal sjr_journal)
        {
            Console.WriteLine("Write the name of the journal file:");
            string sjr_filename = Console.ReadLine();
            try
            {
                sjr_journal.LoadFromString(File.ReadAllText(sjr_filename));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
        }

        static bool ConfirmAction(bool unsaved_progress)
        {
            bool confirm = true;
            if (unsaved_progress)
            {
                confirm = false;
                Console.Write("You have unsaved progress, are you sure you want to exit?\nPress x again to exit, or press any other key to return to the menu: ");
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (option == 'x')
                {
                    confirm = true;
                }
            }
            return confirm;
        }
    }

    static string GeneratePrompt()
    {
        string[] sjr_prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the best thing that I accomplished today?",
        "What did I do today that will help me tomorrow?",
        "What was something that I learned today?"
    ];
        Random sjr_random = new Random();
        string sjr_prompt = sjr_prompts[sjr_random.Next(sjr_prompts.Length)];
        return sjr_prompt;
    }

    static void WriteNewEntry(Journal sjr_journal)
    {
        
    }

    static void DisplayJournal(Journal sjr_journal)
    {
        
    }

    static void SaveJournal(Journal sjr_journal)
    {
        
    }

    static void LoadJournal(Journal sjr_journal)
    {
        
    }

}