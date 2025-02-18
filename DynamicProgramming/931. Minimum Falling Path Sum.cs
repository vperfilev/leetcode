namespace DynamicProgramming;

public sealed class MinimumFallingPathSum 
{
    public class Solution
    {
        public int MinFallingPathSum(int[][] matrix)
        {
            var n = matrix.Length;

            var dp = new int[n, n];
            for (var i = 0; i < n; i++) dp[0, i] = matrix[0][i];

            for (var i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + matrix[i][0];
                dp[i, n - 1] = Math.Min(dp[i - 1, n - 1], dp[i - 1, n - 2]) + matrix[i][n - 1];
                for (var j = 1; j < n - 1; j++)
                    dp[i, j] = matrix[i][j] + Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]), dp[i - 1, j + 1]);
            }

            var minValue = int.MaxValue;
            for (var i = 0; i < n; i++)
                if (minValue > dp[n - 1, i])
                    minValue = dp[n - 1, i];

            return minValue;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[2, 1, 3], [6, 5, 4], [7, 8, 9]];
        
        // Act
        var minFallingPathSum = sut.MinFallingPathSum(matrix);
        
        // Assert
        Assert.Equal(13, minFallingPathSum);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[-19, 57], [-40, -5]];
        
        // Act
        var minFallingPathSum = sut.MinFallingPathSum(matrix);
        
        // Assert
        Assert.Equal(-59, minFallingPathSum);
    }
}