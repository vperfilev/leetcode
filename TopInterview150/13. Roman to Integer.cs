namespace TopInterview150;

public class RomanToInteger
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            var total = 0;
            var previousValue = 0;
            
            foreach (var roman in s)
            {
                var currentValue = RomanCharToDecimal(roman);
                
                if (currentValue <= previousValue)
                {
                    total += previousValue;
                    previousValue = currentValue;
                }
                else
                {
                    previousValue = currentValue - previousValue;
                }
            }

            return total + previousValue;
        }

        private int RomanCharToDecimal(char roman)
        {
            return roman switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new InvalidOperationException()
            };
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var roman = "III";
        
        // Act
        var result = sut.RomanToInt(roman);
        
        // Assert
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var roman = "LVIII";
        
        // Act
        var result = sut.RomanToInt(roman);
        
        // Assert
        Assert.Equal(58, result);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var roman = "MCMXCIV";
        
        // Act
        var result = sut.RomanToInt(roman);
        
        // Assert
        Assert.Equal(1994, result);
    }
}