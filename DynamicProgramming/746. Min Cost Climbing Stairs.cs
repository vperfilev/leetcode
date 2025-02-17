namespace DynamicProgramming;

public sealed class MinCostClimbingStairs {
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            var n = cost.Length;
            var dp = new int[n + 1];

            for (var i = 2; i <= n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            return dp[n];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] cost = [10, 15, 20];
        
        // Act
        var totalCost = sut.MinCostClimbingStairs(cost);
        
        // Assert
        Assert.Equal(15, totalCost);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] cost = [1,100,1,1,1,100,1,1,100,1];
        
        // Act
        var totalCost = sut.MinCostClimbingStairs(cost);
        
        // Assert
        Assert.Equal(6, totalCost);
    }
}