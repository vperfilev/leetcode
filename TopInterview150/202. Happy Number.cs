namespace TopInterview150;

public sealed class HappyNumber 
{
    public class Solution
    {
        public bool IsHappy(int n)
        {
            var seenNumbers = new HashSet<int>();

            while (n != 1 && !seenNumbers.Contains(n))
            {
                seenNumbers.Add(n);
                n = SumOfSquares(n);
            }

            return n == 1;
        }

        private int SumOfSquares(int number)
        {
            var sumOfSquares = 0;
            
            while (number > 0)
            {
                var digit = number % 10;
                number /= 10;
                sumOfSquares += digit * digit;
            }

            return sumOfSquares;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var n = 19;
        
        // Act
        var isHappy = sut.IsHappy(n);
        
        // Assert
        Assert.True(isHappy);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var n = 2;
        
        // Act
        var isHappy = sut.IsHappy(n);
        
        // Assert
        Assert.False(isHappy);
    }
}