using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        
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