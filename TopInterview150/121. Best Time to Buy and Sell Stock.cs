namespace TopInterview150;

public class MaxProfit
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;

            if (!prices.Any()) return maxProfit;
            
            var minprice = prices[0]; 
                
            foreach (var price in prices)
            {
                if(price < minprice)
                    minprice = price;
                    
                var spread = price - minprice;
                if (maxProfit < spread)
                    maxProfit = spread;
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
        Assert.Equal(5, maxProfit);
    }

    [Fact]
    public void Test2()
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