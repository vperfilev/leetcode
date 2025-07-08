using Xunit;

namespace ZyfraClub._25._07;

public sealed class MaximumIceCreamBars 
{
    public class Solution 
    {
        public int MaxIceCream(int[] costs, int coins) 
        {
            Array.Sort(costs);
            for(var i = 0; i < costs.Length; i++)
            {
                if ((coins -= costs[i]) < 0)
                    return i;
            }
            return costs.Length;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] costs = [1,3,2,4,1];
        var coins = 7;
        
        // Act
        var maxIceCream = sut.MaxIceCream(costs, coins);
        
        // Assert
        Assert.Equal(4, maxIceCream);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] costs = [10,6,8,7,7,8];
        var coins = 5;
        
        // Act
        var maxIceCream = sut.MaxIceCream(costs, coins);
        
        // Assert
        Assert.Equal(0, maxIceCream);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] costs = [1,6,3,1,2,5];
        var coins = 20;
        
        // Act
        var maxIceCream = sut.MaxIceCream(costs, coins);
        
        // Assert
        Assert.Equal(6, maxIceCream);
    }
}