namespace DynamicProgramming;

public sealed class Triangle {
    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var m = triangle.Count;
            var dp = new int[m, m];

            dp[0, 0] = triangle[0][0];
            
            for (var i = 1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                for (var j = 1; j < i; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j],dp[i - 1, j - 1]) + triangle[i][j];
                }

                dp[i, i] = dp[i - 1, i - 1] + triangle[i][i];
            }

            var minimum = dp[m - 1, 0];
            for (var i = 1; i < m; i++)
            {
                if (minimum > dp[m - 1, i])
                    minimum = dp[m - 1, i];
            }
            return minimum;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        IList<IList<int>> triangle = [[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]];
        
        // Act
        var path = sut.MinimumTotal(triangle);
        
        // Assert
        Assert.Equal(11, path);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        IList<IList<int>> triangle = [[-10]];
        
        // Act
        var path = sut.MinimumTotal(triangle);
        
        // Assert
        Assert.Equal(-10, path);
    }
}