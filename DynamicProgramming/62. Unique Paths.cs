namespace DynamicProgramming;

public sealed class UniquePaths
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];

            for (var i = 0; i < m; i++)
                dp[i, 0] = 1;
            
            for (var i = 0; i < n; i++)
                dp[0, i] = 1;

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }

            return dp[m - 1, n - 1];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var m = 3;
        var n = 7;

        // Act
        var result = sut.UniquePaths(m, n);

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var m = 3;
        var n = 2;

        // Act
        var result = sut.UniquePaths(m, n);

        // Assert
        Assert.Equal(3, result);
    }
}
