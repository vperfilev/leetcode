namespace TopInterview150;

public sealed class PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;

            Span<int> numbers = stackalloc int[10];
            var r = -1;
            while (x > 0)
            {
                numbers[++r] = x % 10;
                x /= 10;
            }

            var l = 0;
            while (l < r)
                if (numbers[l++] != numbers[r--])
                    return false;
            return true;
        }
    }

    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    public void Test(int x, bool expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var isPalindrome = sut.IsPalindrome(x);

        // Assert
        Assert.Equal(expected, isPalindrome);
    }
}