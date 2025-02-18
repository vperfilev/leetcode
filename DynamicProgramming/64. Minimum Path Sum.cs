namespace DynamicProgramming;

public sealed class MinimumPathSum {
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var dp = new int[m, n];
            dp[0, 0] = grid[0][0];

            for (var i = 1; i < m; i++)
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];

            for (var i = 1; i < n; i++)
                dp[0, i] = dp[0, i - 1] + grid[0][i];

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
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
        int[][] grid = [[1, 3, 1], [1, 5, 1], [4, 2, 1]];
        
        // Act
        var pathCost = sut.MinPathSum(grid);
        
        // Assert
        Assert.Equal(7, pathCost);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] grid = [[1, 2, 3], [4, 5, 6]];
        
        // Act
        var pathCost = sut.MinPathSum(grid);
        
        // Assert
        Assert.Equal(12, pathCost);
    }
}