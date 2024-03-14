namespace VendingMachine.Tests;

using VendingMachineLogic;

public class ChangeCalculatorTests
{
    [Fact]
    public void TotalAmount_IsInitallyZero()
    {
        // Arrange 
        var c = new ChangeCalculator(100);

        Assert.Equal(0, c.TotalAmount);
    }

    [Fact]
    public void TotalAmount_CorrectlyUpdated_WhenAddingCoins()
    {
        const int coinValue = 4;
        var c = new ChangeCalculator(100);
        c.AddCoin(coinValue);

        Assert.Equal(coinValue, c.TotalAmount);
    }

    [Fact]
    public void AddCoins_ThrowsOverflowException_WhenTotalValueExceedsMaxValue()
    {
        var c = new ChangeCalculator(100);

        c.AddCoin(double.MaxValue);

        Assert.Throws<OverflowException>(() => c.AddCoin(1));
    }

    [Fact]
    public void IsEnoughMoney_ReturnsTrue_IfEnoughMoney()
    {
        var c = new ChangeCalculator(100);
        c.AddCoin(200);
        Assert.True(c.IsEnoughMoney);

    }

    [Fact]
    public void IsEnoughMoney_ReturnsFalse_IfToLessMoney()
    {
        var c = new ChangeCalculator(100);
        Assert.False(c.IsEnoughMoney);
    }

    [Fact]
    public void GetChange_ReturnCorrectChange()
    {

        var c = new ChangeCalculator(30);
        c.AddCoin(100);

        var change = c.TotalAmount - c.ProductPrize;

        Assert.Equal(70, change);
    }

    [Fact]
    public void GetChange_ThrowsInvalidOperationException_IfTotalAmountIsToLess()
    {
        var c = new ChangeCalculator(30);
        c.AddCoin(10);

        Assert.Throws<InvalidOperationException>(() => c.GetChange());
    }

}