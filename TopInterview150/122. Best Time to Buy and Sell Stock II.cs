namespace TopInterview150;

public class MaxProfitII
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;
            
            var maxProfit = 0;
            for (var i = 0; i < prices.Length - 1; i++)
            {
                var daySpread = prices[i + 1] - prices[i];
                if (daySpread > 0)
                    maxProfit += daySpread;
            }
            return maxProfit;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [7,1,5,3,6,4];
        
        // Act
        var maxProfit = sut.MaxProfit(nums);

        // Assert
        Assert.Equal(7, maxProfit);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1,2,3,4,5];
        
        // Act
        var maxProfit = sut.MaxProfit(nums);

        // Assert
        Assert.Equal(4, maxProfit);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [7,6,4,3,1];
        
        // Act
        var maxProfit = sut.MaxProfit(nums);

        // Assert
        Assert.Equal(0, maxProfit);
    }
}