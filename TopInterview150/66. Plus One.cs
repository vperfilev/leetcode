namespace TopInterview150;

public sealed class PlusOne
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (++digits[i] < 10) break;
                digits[i] = 0;
            }

            return digits[0] > 0 ? digits : [1, ..digits];
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
    [InlineData(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [InlineData(new[] { 9 }, new[] { 1, 0 })]
    public void Test(int[] digits, int[] expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var plusOne = sut.PlusOne(digits);

        // Assert
        Assert.Equal(expected, plusOne);
    }
}