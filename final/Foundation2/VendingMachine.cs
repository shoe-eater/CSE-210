using System.Data;
using System.Xml;

class VendingMachine
{
    // Bin is a private class of VendingMachine. The program shouldn't be able
    // to access Bin directly.
    private class Bin
    {
        private string _product;
        private float _price;
        private int _count;

        public Bin(string product = "empty", float price = 0, int count = 0)
        {
            if (count < 0 || price < 0)
            {
                throw new ArgumentException();
            }
            _product = product;
            _price = price;
            _count = count;
        }

        public string GetProduct()
        {
            return _product;
        }

        public float GetPrice()
        {
            return _price;
        }

        public void Stock(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException();
            }
            _count += count;
        }

        public void Dispense()
        {
            _count--;
            if (_count == 0)
            {
                _product = "empty";
                _price = 0;
            }
        }

        public string ToSave()
        {
            if (_product == "empty")
            {
                return "";
            }
            else
            {
                return $"{_product}, {_price}, {_count}";
            }
        }
    }

    private Bin[][] _bins;
    private float _moneyCollected;
    private float _moneyInserted;

    public VendingMachine(List<int> rows, float moneyCollected = 0)
    {
        _bins = new Bin[rows.Count][];

        for (int i = 0; i < rows.Count; i++)
        {
            _bins[i] = new Bin[rows[i]];

            for (int j = 0; j < rows[i]; j++)
            {
                _bins[i][j] = new Bin();
            }
        }

        _moneyCollected = moneyCollected;
        _moneyInserted = 0;
    }

    public string GetProduct(string code)
    {
        (char, int) location = ParseCode(code);
        return _bins[LetterIndex(location.Item1)][location.Item2].GetProduct();
    }

    public string ListProducts()
    {
        string output = "Vending Machine:\n\n";

        for (int i = 0; i < _bins.Length; i++)
        {
            for (int j = 0; j < _bins[i].Length; j++)
            {
                output += $"{LetterIndex(i)}{j + 1}:\t{_bins[i][j].GetProduct(), -32} {_bins[i][j].GetPrice(), -8:C}\n";
            }
        }

        return output;
    }

    public string ListProducts(string product)
    {
        string output = $"You can put the product {product} in these spots:\n\n";
        bool noRoom = true;

        for (int i = 0; i < _bins.Length; i++)
        {
            for (int j = 0; j < _bins[i].Length; j++)
            {
                if (_bins[i][j].GetProduct() == "empty" || _bins[i][j].GetProduct() == product)
                {
                    output += $"{LetterIndex(i)}{j + 1}:\t{_bins[i][j].GetProduct(), -32} {_bins[i][j].GetPrice(), -8:C}\n";
                    noRoom = false;
                }
            }
        }

        if (noRoom)
        {
            throw new ArgumentException("There is no room for that product.");
        }

        return output;
    }

    public void StockBin(string code, string product, float price, int count)
    {
        (char, int) location = ParseCode(code);
        _bins[LetterIndex(location.Item1)][location.Item2] = new Bin(product, price, count);
    }

    public void StockBin(string code, int count)
    {
        (char, int) location = ParseCode(code);
        _bins[LetterIndex(location.Item1)][location.Item2].Stock(count);
    }

    public void EmptyBin(string code)
    {
        (char, int) location = ParseCode(code);
        _bins[LetterIndex(location.Item1)][location.Item2] = new Bin();
    }

    public float ViewMoney()
    {
        return _moneyCollected;
    }

    public float ViewCredit()
    {
        return _moneyInserted;
    }

    public void InsertMoney(float moneyInserted)
    {
        if (moneyInserted >= 0)
        {
            _moneyInserted += moneyInserted;
        }
        else
        {
            throw new ArgumentException("You cannot enter negative money.");
        }
    }

    public (string, float) EnterCode(string code)
    {
        (char, int) location = ParseCode(code);
        Bin bin = _bins[LetterIndex(location.Item1)][location.Item2];
        string product = bin.GetProduct();
        float price = bin.GetPrice();

        if (product == "empty")
        {
            throw new ArgumentException("This product is out of stock.");
        }

        if (_moneyInserted >= price)
        {
            bin.Dispense();
            _moneyCollected += price;
            _moneyInserted -= price;
        }
        else
        {
            throw new ArgumentException("You do not have enough credit to buy this product.");
        }
        
        return (product, price);
    }

    public float ReturnChange()
    {
        float change = _moneyInserted;
        _moneyInserted = 0;
        return change;
    }

    public string ToSave()
    {
        string output = $"{_moneyCollected}\n";

        foreach (Bin[] row in _bins)
        {
            output += $"{row.Length}, ";
        }
        output = output.Remove(output.Length - 2);

        for (int i = 0; i < _bins.Length; i++)
        {
            for (int j = 0; j < _bins[i].Length; j++)
            {
                if (_bins[i][j].GetProduct() != "empty")
                {
                    output += $"\n{LetterIndex(i)}{j + 1}, {_bins[i][j].ToSave()}";
                }
            }
        }

        return output;
    }

    private int LetterIndex(char letter)
    {
        return char.ToUpper(letter) - 'A';
    }

    private char LetterIndex(int index)
    {
        return (char)(index + 'A');
    }

    private (char, int) ParseCode(string code)
    {
        char codeLetter = code[0];
        int codeNumber = int.Parse(code.Substring(1)) - 1;
        return (codeLetter, codeNumber);
    }
}