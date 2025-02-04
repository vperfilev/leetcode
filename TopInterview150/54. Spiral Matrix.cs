namespace TopInterview150;

public sealed class SpiralMatrix
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var left = 0;
            var top = 0;
            var right = matrix[0].Length - 1;
            var bottom = matrix.Length - 1;
            var result = new List<int>(matrix.Length * matrix[0].Length);

            while (left <= right && top <= bottom)
            {
                for (var i = left; i <= right; i++)
                    result.Add(matrix[top][i]);
                top++;
                
                for (var i = top; i <= bottom; i++)
                    result.Add(matrix[i][right]);
                right--;

                if (top <= bottom)
                {
                    for (var i = right; i >= left; i--)
                        result.Add(matrix[bottom][i]);
                    bottom--;
                }
                
                if (left <= right)
                {
                    for (var i = bottom; i >= top; i--)
                        result.Add(matrix[i][left]);
                    left++;
                }
            }

            return result;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[1,2,3],[4,5,6],[7,8,9]];
        
        // Act
        var spiralOrder = sut.SpiralOrder(matrix);
        
        // Assert
        Assert.Equal([1,2,3,6,9,8,7,4,5], spiralOrder);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]];
        
        // Act
        var spiralOrder = sut.SpiralOrder(matrix);
        
        // Assert
        Assert.Equal([1,2,3,4,8,12,11,10,9,5,6,7], spiralOrder);
    }
}