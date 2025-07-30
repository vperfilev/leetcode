namespace TopInterview150;

public sealed class FactorialTrailingZeroes 
{
    public class Solution 
    {
        public int TrailingZeroes(int n) 
        {
            var zeroes = 0;
            var d = 5;
            while(d <= n)
            {
                zeroes += n / d;
                d *= 5;
            }
            return zeroes;
        }
    }

    [Theory]
    [InlineData(3, 0)]
    [InlineData(5, 1)]
    [InlineData(0, 0)]
    public void MethodName(int n, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var trailingZeroes = sut.TrailingZeroes(n);
        
        // Assert
        Assert.Equal(expected, trailingZeroes);
    }
}