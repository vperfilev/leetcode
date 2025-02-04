namespace TopInterview150;

public sealed class RotateImage
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            var startPos = 0;
            var sideLen = matrix[0].Length - 1;

            while (sideLen >= 1)
            {
                for (var i = 0; i < sideLen; i++)
                {
                    var tmp = matrix[startPos][startPos + i];
                    matrix[startPos][startPos + i] = matrix[startPos + sideLen - i][startPos];
                    matrix[startPos + sideLen - i][startPos] = matrix[startPos + sideLen][startPos + sideLen - i];
                    matrix[startPos + sideLen][startPos + sideLen - i] = matrix[startPos + i][startPos + sideLen];
                    matrix[startPos + i][startPos + sideLen] = tmp;
                }

                startPos++;
                sideLen -= 2;
            }
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[1,2,3],[4,5,6],[7,8,9]];
        
        // Act
        sut.Rotate(matrix);
        
        // Assert
        Assert.Equal([[7,4,1],[8,5,2],[9,6,3]], matrix);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]];
        
        // Act
        sut.Rotate(matrix);
        
        // Assert
        Assert.Equal([[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]], matrix);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[][] matrix = [[2,29,20,26,16,28],[12,27,9,25,13,21],[32,33,32,2,28,14],[13,14,32,27,22,26],[33,1,20,7,21,7],[4,24,1,6,32,34]];
        
        // Act
        sut.Rotate(matrix);
        
        // Assert
        Assert.Equal([[4,33,13,32,12,2],[24,1,14,33,27,29],[1,20,32,32,9,20],[6,7,27,2,25,26],[32,21,22,28,13,16],[34,7,26,14,21,28]], matrix);
    }

}