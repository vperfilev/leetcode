namespace DynamicProgramming;

public sealed class NthTribonacciNumber {
    public class Solution
    {
        public int Tribonacci(int n)
        {
            if (n < 2) return n;
            var dp = new int[n + 1];
            dp[1] = dp[2] = 1;

            for (var i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            return dp[n];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var n = 4;
        
        // Act
        var tribonacci = sut.Tribonacci(n);
        
        // Assert
        Assert.Equal(4, tribonacci);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var n = 25;

        // Act
        var tribonacci = sut.Tribonacci(n);
        
        // Assert
        Assert.Equal(1389537, tribonacci);
    }
}