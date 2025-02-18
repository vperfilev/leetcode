namespace DynamicProgramming;

public sealed class MaximalSquare
{
    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dp = new int[m, n];

            var maxSide = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        }
                        maxSide = Math.Max(dp[i, j], maxSide);
                    }
                }
            }

            return maxSide * maxSide;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        char[][] matrix = [['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']];

        // Act
        var area = sut.MaximalSquare(matrix);

        // Assert
        Assert.Equal(4, area);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        char[][] matrix = [['0', '1'], ['1', '0']];

        // Act
        var area = sut.MaximalSquare(matrix);

        // Assert
        Assert.Equal(1, area);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        char[][] matrix = [['0']];

        // Act
        var area = sut.MaximalSquare(matrix);

        // Assert
        Assert.Equal(0, area);
    }
}