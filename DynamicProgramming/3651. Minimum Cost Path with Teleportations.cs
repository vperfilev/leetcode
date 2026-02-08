namespace DynamicProgramming;

public sealed class MinimumCostPathWithTeleportations 
{
    public class Solution 
    {
        public int MinCost(int[][] grid, int k) 
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            
            var dp = new int[k + 1, rows + 1, cols + 1];

            for (var i = 0; i < dp.GetLength(1); i++)
            for (var j = 0; j < dp.GetLength(2); j++)
            for (var c = 0; c < dp.GetLength(0); c++)
                dp[c, i, j] = int.MaxValue;

            dp[0, 1, 1] = grid[0][0];
            
            var maxCellValue = grid.SelectMany(r => r).Max();
            Span<int> prevLevelPatches = stackalloc int[maxCellValue + 1];
            Span<int> bestPatches = stackalloc int[maxCellValue + 1];
            
            for (var i = 0; i < prevLevelPatches.Length; i++)
                prevLevelPatches[i] = int.MaxValue;
            
            for (var l = 0; l <= k; l++)
            {
                for (var i = 0; i < bestPatches.Length; i++)
                    bestPatches[i] = int.MaxValue;

                bestPatches[grid[0][0]] = dp[l, 1, 1];
                
                for(var row = 1; row <= rows; row++)
                {
                    for (var col = 1; col <= cols; col++)
                    {
                        if (row == 1 && col == 1) continue;
                        
                        var cellPrice = grid[row - 1][col - 1];
                        
                        var moveCost = Math.Min(dp[l, row - 1, col], dp[l, row, col - 1]);
                        if (moveCost != int.MaxValue)
                            moveCost += cellPrice;
                        
                        var teleportCost = prevLevelPatches[cellPrice];
                        var best = Math.Min(moveCost, teleportCost);
                        dp[l, row, col] = best;
                        
                        bestPatches[cellPrice] = Math.Min(best, bestPatches[cellPrice]);
                    }
                }

                var minPrice = int.MaxValue;
                for (var i = bestPatches.Length - 1; i >= 0; i--)
                {
                    if (bestPatches[i] < minPrice) minPrice = bestPatches[i];
                    prevLevelPatches[i] = minPrice;
                }
            }

            var result = int.MaxValue;
            for(var l = 0; l <= k; l++)
                result = Math.Min(result, dp[l, rows, cols]);

            return result - grid[0][0];
        }

        [Fact]
        public void Case1_Grid2x2_K7_Returns4()
        {
            int [][] grid =
            [
                [3, 1],
                [10, 4]
            ];
            const int k = 7;
            
            var sol = new Solution();
            var actual = sol.MinCost(grid, k);
            
            Assert.Equal(4, actual);
        }
        
        [Fact]
        public void Case1_Grid3x3_K2_Returns7()
        {
            int[][] grid =
            [
                [1, 3, 3],
                [2, 5, 4],
                [4, 3, 5]
            ];
            const int k = 2;

            var sol = new Solution();
            var actual = sol.MinCost(grid, k);

            Assert.Equal(7, actual);
        }

        [Fact]
        public void Case2_Grid3x2_K1_Returns9()
        {
            int[][] grid =
            [
                [1, 2],
                [2, 3],
                [3, 4]
            ];
            const int k = 1;

            var sol = new Solution();
            var actual = sol.MinCost(grid, k);

            Assert.Equal(9, actual);
        }
    }  
}