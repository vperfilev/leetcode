using Xunit;

namespace ZyfraClub._25._06;

public sealed class CountSymmetricIntegers
{
    public class Solution
    {
        public int CountSymmetricIntegers(int low, int high)
        {
            var count = 0;
            Span<int> digits = stackalloc int[6];
            
            for (var i = low; i <= high; i++)
            {
                var numberRest = i;
                var digitCount = 0;
                
                while (numberRest > 0)
                {
                    digits[digitCount++] = numberRest % 10;
                    numberRest /= 10;
                }

                if (digitCount % 2 == 1)
                {
                    i = (int)Math.Pow(10, digitCount);
                    continue;
                }

                int leftSum = 0, rightSum = 0, l = -1, r = digitCount;
                while (++l < --r)
                {
                    leftSum += digits[l];
                    rightSum += digits[r];
                }

                if (leftSum == rightSum)
                    count++;
            }

            return count;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var low = 1;
        var high = 100;
        
        // Act
        var count = sut.CountSymmetricIntegers(low, high);
        
        // Assert
        Assert.Equal(9, count);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var low = 1200;
        var high = 1230;
        
        // Act
        var count = sut.CountSymmetricIntegers(low, high);
        
        // Assert
        Assert.Equal(4, count);
    }
}