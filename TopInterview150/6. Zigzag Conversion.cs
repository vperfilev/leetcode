using System.Text;

namespace TopInterview150;

public class ZigzagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (s.Length < 3 || numRows == 1 || numRows >= s.Length)
                return s;

            var lines = Enumerable.Range(0, numRows)
                .Select(x => new StringBuilder()).ToArray();
            
            var currentLine = 0;
            var goingDown = true;

            foreach (var letter in s)
            {
                lines[currentLine].Append(letter);
                currentLine += goingDown ? 1 : -1;
                if (currentLine == 0 || currentLine == numRows - 1)
                    goingDown = !goingDown;
            }

            return string.Concat(lines.Select(x => x.ToString()));
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "PAYPALISHIRING";
        var numRows = 4;
        
        // Act
        var converted = sut.Convert(s, numRows);
        
        // Assert
        Assert.Equal("PINALSIGYAHRPI", converted);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "PAYPALISHIRING";
        var numRows = 3;
        
        // Act
        var converted = sut.Convert(s, numRows);
        
        // Assert
        Assert.Equal("PAHNAPLSIIGYIR", converted);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "A";
        var numRows = 1;
        
        // Act
        var converted = sut.Convert(s, numRows);
        
        // Assert
        Assert.Equal("A", converted);
    }
}