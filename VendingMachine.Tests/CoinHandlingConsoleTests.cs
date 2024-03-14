namespace VendingMachineLogic;

public class CoinHandlingConsoleTests
{
    [Fact]
    public void ValidCoins_ShouldReturnNoChange()
    {
        var inputs = new string[] { "1,5E", "1E", "50C" };
        var chcm = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(0, chcm.HandleCoins());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 1E",
                "Coin: ",
                "Total: 1,5E",
                "Change: 0E"
            ], chcm.Outputs);
    }

    [Fact]
    public void AddValidCoins_ReturnChange()
    {
        var inputs = new string[] { "1,5E", "1E", "2E" };
        var chcm = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(1.5, chcm.HandleCoins());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 1E",
                "Coin: ",
                "Total: 3E",
                "Change: 1,5E"
            ], chcm.Outputs);
    }


    [Fact]
    public void InvalidCoinsEntered()
    {
        var inputs = new string[] { "3,5E", "1E", "12D", "2E", "1E" };
        var chcm = new CoinHandlingConsoleMock(inputs);

        Assert.Equal(0.5, chcm.HandleCoins());
        Assert.Equal(
            [
                "Price: ",
                "Coin: ",
                "Total: 1E",
                "Coin: ",
                "Invalid Coin",
                "Coin: ",
                "Total: 3E",
                "Coin: ",
                "Total: 4E",
                "Change: 0,5E"

            ], chcm.Outputs);
    }
}