namespace DynamicProgramming;

public sealed class UniquePaths2 
{
    public class Solution
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;
            
            var dp = new int[m, n];


            var faceObstacle = false;
            for (var i = 0; i < m; i++)
            {
                if (obstacleGrid[i][0] == 1) faceObstacle = true;
                dp[i, 0] = faceObstacle ? int.MaxValue : 1;
            }

            faceObstacle = false;
            for (var i = 0; i < n; i++)
            {
                if (obstacleGrid[0][i] == 1) faceObstacle = true;
                dp[0, i] = faceObstacle ? int.MaxValue : 1;
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i, j] = int.MaxValue;
                    }
                    else
                    {
                        dp[i, j] = (dp[i, j - 1], dp[i - 1, j]) switch
                        {
                            (int.MaxValue, int.MaxValue) => int.MaxValue,
                            (var a, int.MaxValue) => a,
                            (int.MaxValue, var b) => b,
                            var (a, b) => a + b
                        };
                    }
                }
            }

            return dp[m - 1, n - 1] == int.MaxValue ? 0 : dp[m - 1, n - 1];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] obstacleGrid = [[0, 0, 0], [0, 1, 0], [0, 0, 0]];
        
        // Act
        var pathCount = sut.UniquePathsWithObstacles(obstacleGrid);
        
        // Assert
        Assert.Equal(2, pathCount);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] obstacleGrid = [[0, 1], [0, 0]];
        
        // Act
        var pathCount = sut.UniquePathsWithObstacles(obstacleGrid);
        
        // Assert
        Assert.Equal(1, pathCount);
    }
}