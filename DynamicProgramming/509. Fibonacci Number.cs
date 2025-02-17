namespace DynamicProgramming;

public sealed class FibonacciNumber {
    public class Solution
    {
        public int Fib(int n)
        {
            if (n < 2) return n;
            var dp = new int[n+1];

            dp[1] = dp[2] = 1;

            for (int i = 3; i <= n; i++)
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
        var fib = sut.Fib(n);
        
        // Assert
        Assert.Equal(1, fib);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var n = 3;
            
        // Act
        var fib = sut.Fib(n);
        
        // Assert
        Assert.Equal(2, fib);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var n = 4;
            
        // Act
        var fib = sut.Fib(n);
        
        // Assert
        Assert.Equal(3, fib);
    }
}