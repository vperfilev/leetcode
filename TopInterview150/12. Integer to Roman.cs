namespace TopInterview150;

public class IntegerToRoman
{
    public class Solution
    { 
        public string IntToRoman(int num)
        {
            var roman = new List<char>();
            
            while (num > 0)
            {
                var (r, n) = ExtractRoman(num);
                num -= n;
                roman.Add(r);
            }

            return string.Concat(roman);
        }

        private (char roman, int value) ExtractRoman(int num)
        {
            return num switch
            {
                >= 1000 => ('M', 1000),
                >= 900 => ('C', -100),
                >= 500 => ('D', 500),
                >= 400 => ('C', -100),
                >= 100 => ('C', 100),
                >= 90 => ('X', -10),
                >= 50 => ('L', 50),
                >= 40 => ('X', -10),
                >= 10 => ('X', 10),
                9 => ('I', -1),
                >= 5 => ('V', 5),
                4 => ('I', -1),
                >= 1 => ('I', 1),
                _ => throw new ArgumentOutOfRangeException(nameof(num))
            };
        }
    }

    [Fact]
    public void Test1()
    { 
        // Arrange
        var sut = new Solution();
        var num = 3749;
        
        // Act
        var roman = sut.IntToRoman(num);

        // Assert
        Assert.Equal("MMMDCCXLIX", roman);
    }
    
    [Fact]
    public void Test2()
    { 
        // Arrange
        var sut = new Solution();
        var num = 58;
        
        // Act
        var roman = sut.IntToRoman(num);

        // Assert
        Assert.Equal("LVIII", roman);
    }

    [Fact]
    public void Test3()
    { 
        // Arrange
        var sut = new Solution();
        var num = 1994;
        
        // Act
        var roman = sut.IntToRoman(num);

        // Assert
        Assert.Equal("MCMXCIV", roman);
    }
}