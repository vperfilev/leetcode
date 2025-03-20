namespace TopInterview150;

public class GameOfLife
{
    public class Solution
    {
        public void GameOfLife(int[][] board)
        {
            for (var col = 0; col < board[0].Length; col++)
            {
                for (var row = 0; row < board.Length; row++)
                {
                    var isAlive = board[row][col] == 1;

                    var nextState = (isAlive, NeighborsCount(row, col)) switch
                    {
                        (true, < 2) => false,
                        (true, <= 3) => true,
                        (true, > 3) => false,
                        (false, 3) => true,
                        (false, _) => false
                    };
                    board[row][col] |= nextState ? 2 : 0;
                }
            }

            for (var col = 0; col < board[0].Length; col++)
                for (var row = 0; row < board.Length; row++)
                    board[row][col] >>= 1;

            return;

            int NeighborsCount(int row, int col)
            {
                var count = 0;
                for (var rowIndex = Math.Max(0, row - 1); rowIndex <= Math.Min(board.Length - 1, row + 1); rowIndex++)
                {
                    for (var colIndex = Math.Max(0, col - 1); colIndex <= Math.Min(board[0].Length - 1, col + 1); colIndex++)
                    {
                        if (rowIndex == row && colIndex == col) continue;
                        count += board[rowIndex][colIndex] & 1;
                    }
                }
                return count;
            }
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] board = [[0,1,0],[0,0,1],[1,1,1],[0,0,0]]; 
        
        // Act
        sut.GameOfLife(board);

        // Assert
        Assert.Equal([[0,0,0],[1,0,1],[0,1,1],[0,1,0]], board);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] board = [[1,1],[1,0]]; 
        
        // Act
        sut.GameOfLife(board);

        // Assert
        Assert.Equal([[1,1],[1,1]], board);
    }
}