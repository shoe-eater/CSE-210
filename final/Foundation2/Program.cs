using System;

class Program
{
    static void Main(string[] args)
    {
        VendingMachine vendingMachine = null;
        bool stayInMainLoop = true;

        // The beginning of the program handles loading a vending machine file.
        Console.Write("Enter the name of a vending machine file, or press enter with no input to create a new, empty vending machine: ");
        string filename = Console.ReadLine();
        Console.Clear();

        // CreateVendingMachine() is overloaded. Providing a file name opens a file,
        // but providing nothing initiates creating a new vending machine.
        if (filename == "")
        {
            vendingMachine = CreateVendingMachine();
        }
        else
        {
            try
            {
                vendingMachine = CreateVendingMachine(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                stayInMainLoop = false;
            }
        }

        // Main menu loop
        while (stayInMainLoop)
        {
            Console.WriteLine("Vending machine main menu:\n1: Use the machine.\n2: Service the machine.\n3: Save and quit.");
            char option1 = Console.ReadKey().KeyChar;
            Console.Clear();
            char option2;
            bool stayInSubLoop = true;

            switch (option1)
            {
                case '1':
                // Customer menu loop
                while (stayInSubLoop)
                {
                    Console.WriteLine("Customer menu:\n1: View products.\n2: Insert money.\n3: Select an item.\n4: Get change and leave.");
                    option2 = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (option2)
                    {
                        case '1':
                        Console.WriteLine(vendingMachine.ListProducts());
                        Console.WriteLine($"\nYou have {vendingMachine.ViewCredit():C} in the machine.");
                        break;

                        case '2':
                        InsertMoney(vendingMachine);
                        break;
                    
                        case '3':
                        EnterCode(vendingMachine);
                        break;

                        case '4':
                        ReturnChange(vendingMachine);
                        stayInSubLoop = false;
                        break;
                    }

                    PressAnyKey();
                }
                break;
            
                case '2':
                // Employee menu loop
                while (stayInSubLoop)
                {
                    Console.WriteLine("Employee menu:\n1: View products.\n2: Restock machine.\n3: View money.\n4: Empty a bin.\n5: Leave.");
                    option2 = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (option2)
                    {
                        case '1':
                        Console.WriteLine(vendingMachine.ListProducts());
                        break;

                        case '2':
                        StockMachine(vendingMachine);
                        break;

                        case '3':
                        Console.WriteLine($"There is {vendingMachine.ViewMoney():C} in the machine.");
                        break;

                        case '4':
                        Console.Write("Enter a bin to empty: ");
                        string code = Console.ReadLine();
                        vendingMachine.EmptyBin(code);
                        Console.WriteLine("Bin emptied.");
                        break;

                        case '5':
                        stayInSubLoop = false;
                        break;
                    }

                    if (stayInSubLoop)
                    {
                        PressAnyKey();
                    }
                }
                break;
            
                case '3':
                // Save and exit
                Console.Write("Enter a file name to save this vending machine: ");
                filename = Console.ReadLine();
                File.WriteAllText(filename, vendingMachine.ToSave());
                Console.WriteLine("File saved.");
                stayInMainLoop = false;
                break;
            }
        }
    }

    static private VendingMachine CreateVendingMachine()
    {
        // The new vending machine starts as a list for dynamic creation.
        List<int> rows = new List<int>();
        int input = 0;

        // The vending machine must have at least one row.
        while (input <= 0)
        {
            Console.Write("Enter the number of bins in the first row (must be more than 0): ");
            input = int.Parse(Console.ReadLine());
            Console.Clear();
        }
        while (input > 0)
        {
            rows.Add(input);
            Console.Write("Enter the number of bins in the next row, or enter 0 if done: ");
            input = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        return new VendingMachine(rows);
    }

    static private VendingMachine CreateVendingMachine(string filename)
    {
        // Uses StreamReader for easier reading.
        StreamReader fileStream = new StreamReader(filename);

        // First line is money collected.
        float moneyCollected = float.Parse(fileStream.ReadLine());

        // Second line is the vending machine structure.
        string rowsString = fileStream.ReadLine();
        List<int> rows = new List<int>();
        foreach (string rowString in rowsString.Split(", "))
        {
            rows.Add(int.Parse(rowString));
        }
        VendingMachine vendingMachine = new VendingMachine(rows, moneyCollected);

        // Every line after is the contents of the machine.
        string line;
        while ((line = fileStream.ReadLine()) != null)
        {
            string[] data = line.Split(", ");
            vendingMachine.StockBin(data[0], data[1], float.Parse(data[2]), int.Parse(data[3]));
        }

        fileStream.Close();

        return vendingMachine;
    }

    static private void PressAnyKey()
    {
        // Function to wait for key press that is repeated in many places.
        Console.Write("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    static private void InsertMoney(VendingMachine vendingMachine)
    {
        try
        {
            Console.Write("Enter an amount of money to insert: ");
            float money = float.Parse(Console.ReadLine());
            vendingMachine.InsertMoney(money);
            Console.WriteLine("Money inserted.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number entered.");
        }
    }

    static private void EnterCode(VendingMachine vendingMachine)
    {
        // Attempts to buy a product from the vending machine.

        try
        {
            Console.Write("Enter a code: ");
            string code = Console.ReadLine();
            Console.Clear();
            (string, float) purchase = vendingMachine.EnterCode(code);
            Console.WriteLine($"You purchased a {purchase.Item1} for {purchase.Item2:C}.");
        }
        catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid code.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static private void ReturnChange(VendingMachine vendingMachine)
    {
        float change = vendingMachine.ReturnChange();
        Console.WriteLine($"You recieved ${change} back.");
    }

    static private void StockMachine(VendingMachine vendingMachine)
    {
        // A method that asks what product is being stocked, then provides the user with
        // valid spots to put it in, rather than letting them put any product wherever.
        try
        {
            Console.Write("Enter the product you are stocking: ");
            string product = Console.ReadLine();
            Console.Write("Enter how many of this product you are stocking: ");
            int count = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write(vendingMachine.ListProducts(product));
            Console.Write("Enter a bin to restock this product: ");
            string code = Console.ReadLine();
            Console.Clear();
            string productInBin = vendingMachine.GetProduct(code);
            if (productInBin == "empty")
            {
                Console.Write("This bin is empty.\nEnter a price for the new product: ");
                float price = float.Parse(Console.ReadLine());
                Console.Clear();
                vendingMachine.StockBin(code, product, price, count);
            }
            else if (productInBin == product)
            {
                vendingMachine.StockBin(code, count);
            }
            else
            {
                throw new ArgumentException("There is a different product already there.");
            }
            Console.WriteLine("Product stocked.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid code.");
        }
        catch (Exception ex) when (ex is FormatException)
        {
            Console.WriteLine("Invalid number entered.");
        }
    }
}