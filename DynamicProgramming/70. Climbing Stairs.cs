namespace DynamicProgramming;

public class ClimbingStairs
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n <= 2) return n;

            var dp = new int[n + 1];

            dp[1] = 1;
            dp[2] = 2;

            for (var i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var n = 2;
        // Act
        var result = sut.ClimbStairs(n);
        
        // Assert
        Assert.Equal(2, n);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var n = 3;
        // Act
        var result = sut.ClimbStairs(n);
        
        // Assert
        Assert.Equal(3, n);
    }
}