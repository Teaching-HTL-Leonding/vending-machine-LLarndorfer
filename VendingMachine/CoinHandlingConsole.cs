namespace VendingMachineLogic;

using VendingMachineLogic;

public class CoinHandlingConsole
{
    public virtual void WriteLine(string s) => Console.WriteLine(s);

    public virtual string ReadLine() => Console.ReadLine()!;
    public double HandleCoins()
    {
        double price = 0;
        var c = new Coin();
        WriteLine("Price: ");
        string input = ReadLine();
        if (input.Contains("C"))
        {
            input = input.Replace("C", "");
            price = double.Parse(input);
            price = price / 100;
        }
        else if (input.Contains("E"))
        {
            price = double.Parse(input.Replace("E", ""));
        }
        else
        {
            throw new FormatException("Total input must contain E or C at the End");
        }


        var cc = new ChangeCalculator(price);
        do
        {
            WriteLine("Coin: ");
            input = ReadLine();

            try
            {
                price = c.Parse(input);
                cc.AddCoin(price / 100d);
                WriteLine($"Total: {cc.TotalAmount}E");
            }
            catch (FormatException)
            {
                WriteLine("Invalid Coin");
            }
        }
        while (!cc.IsEnoughMoney);
        double Change = cc.GetChange();

        WriteLine($"Change: {Change}E");
        return Change;
    }
}