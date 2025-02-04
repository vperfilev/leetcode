namespace TopInterview150;

public sealed class IsValidSudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (var i = 0; i < 9; i++)
            {
                var rowSet = new HashSet<char>();
                var columnSet = new HashSet<char>();
                var cubeSet = new HashSet<char>();
                
                for (var j = 0; j < 9; j++)
                {
                    if (board[i][j] is var r && r != '.' && !rowSet.Add(r))
                        return false;

                    if (board[j][i] is var c && c != '.' && !columnSet.Add(c))
                        return false;

                    var boxCol = (i / 3) * 3 + j / 3;
                    var boxRow = (i % 3) * 3 + j % 3;

                    if (board[boxCol][boxRow] is var b && b != '.' && !cubeSet.Add(b))
                        return false;
                }
            }

            return true;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        char[][] board =
        [
            ['5', '3', '.', '.', '7', '.', '.', '.', '.'], 
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'], 
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'], 
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'], 
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9']
        ];

        // Act
        var isValid = sut.IsValidSudoku(board);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        char[][] board =
        [
            ['8','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']
        ];

        // Act
        var isValid = sut.IsValidSudoku(board);

        // Assert
        Assert.False(isValid);
    }
}