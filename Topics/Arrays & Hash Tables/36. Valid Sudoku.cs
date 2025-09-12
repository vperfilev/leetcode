using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class ValidSudoku 
{
    public class Solution 
    {
        public bool IsValidSudoku(char[][] board)
        {
            var lines = new int[9];
            var columns = new int[9];
            var squares = new int[9];

            for (var l = 0; l < 9; l++)
            {
                for (var c = 0; c < 9; c++)
                {
                    var value = _pareser[board[l][c]];
                    if ((lines[l] & value) > 0) return false;
                    lines[l] |= value;
                    
                    if ((columns[c] & value) > 0) return false;
                    columns[c] |= value;

                    var squareIndex = c / 3 + l / 3 * 3;
                    if ((squares[squareIndex] & value) > 0) return false;
                    squares[squareIndex] |= value;
                }
            }

            return true;
        }

        private Dictionary<char, int> _pareser = new()
        {
            ['0'] = 1 << 0,
            ['1'] = 1 << 1,
            ['2'] = 1 << 2,
            ['3'] = 1 << 3,
            ['4'] = 1 << 4,
            ['5'] = 1 << 5,
            ['6'] = 1 << 6,
            ['7'] = 1 << 7,
            ['8'] = 1 << 8,
            ['9'] = 1 << 9,
            ['.'] = 0,
        };
    }

    [Fact]
    public void Test1()
    {
        // Arrange 
        var sut = new Solution();
        char[][] board =
        [
            ['5','3','.','.','7','.','.','.','.'],
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
        var isValidSudoku = sut.IsValidSudoku(board);

        // Assert
        Assert.True(isValidSudoku);
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
        var isValidSudoku = sut.IsValidSudoku(board);

        // Assert
        Assert.False(isValidSudoku);
    }
}