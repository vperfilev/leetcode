namespace TopInterview150;

public sealed class SetMatrixZeroes 
{
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            var firstRowZero = matrix[0].Any(x => x == 0);
            var firstColZero = matrix.Any(x => x[0] == 0);
            var colCount = matrix[0].Length;
            var rowCount = matrix.Length;
            
            for (var i = 1; i < rowCount; i++)
            {
                for (var j = 1; j < colCount; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            
            for (var i = 1; i < rowCount; i++)
            {
                for (var j = 1; j < colCount; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            
            if (firstColZero)
                for (var i = 0; i < rowCount; i++)
                {
                    matrix[i][0] = 0;
                }
            
            if (firstRowZero)
                for (var i = 0; i < colCount; i++)
                {
                    matrix[0][i] = 0;
                }
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[1,1,1],[1,0,1],[1,1,1]];
        
        // Act
        sut.SetZeroes(matrix);
        
        // Assert
        Assert.Equal([[1,0,1],[0,0,0],[1,0,1]], matrix);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]];
        
        // Act
        sut.SetZeroes(matrix);
        
        // Assert
        Assert.Equal([[0,0,0,0],[0,4,5,0],[0,3,1,0]], matrix);
    }
}