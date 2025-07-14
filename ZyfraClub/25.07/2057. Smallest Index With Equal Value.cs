using Xunit;

namespace ZyfraClub._25._07;

public sealed class SmallestIndexWithEqualValue
{
    public class Solution
    {
        public int SmallestEqual(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
                if (i % 10 == nums[i])
                    return i;

            return -1;
        }
    }

    [Theory]
    [InlineData(new[] { 0, 1, 2 }, 0)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, -1)]
    public void MethodName(int[] nums, int expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var index = sut.SmallestEqual(nums);

        // Assert
        Assert.Equal(expected, index);
    }
}