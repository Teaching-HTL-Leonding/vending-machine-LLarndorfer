namespace VendingMachineLogic;

public class Coin
{
    public int Parse(string s)
    {
        switch (s)
        {
            case "2E":
                return 200;

            case "1E":
                return 100;

            case "50C":
                return 50;

            case "20C":
                return 20;

            case "10C":
                return 10;

            default:
                throw new FormatException("Invalid Format of Input!");
        }
    }
}

public class ChangeCalculator(double productPrize)
{
    public double ProductPrize { get; set; } = productPrize;
    public double TotalAmount { get; private set; } = 0;
    public bool IsEnoughMoney => TotalAmount >= ProductPrize;
    public double AddCoin(double coin)
    {
        return checked(TotalAmount += coin);
    }

    public double GetChange()
    {
        if (IsEnoughMoney)
        {
            return TotalAmount - ProductPrize;
        }
        else
        {
            throw new InvalidOperationException("To less money!");
        }
    }

}

