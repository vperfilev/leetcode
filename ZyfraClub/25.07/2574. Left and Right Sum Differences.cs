using Xunit;

namespace ZyfraClub._25._07;

public sealed class LeftAndRightSumDifferences
{
    public class Solution
    {
        public int[] LeftRightDifference(int[] nums)
        {
            var result = new int[nums.Length];

            var total = nums.Sum();
            var leftSum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var rightSum = total - nums[i] - leftSum;
                result[i] = Math.Abs(leftSum - rightSum);
                leftSum += nums[i];
            }

            return result;
        }
    }

    [Theory]
    [InlineData(new[] { 10, 4, 8, 3 }, new[] { 15, 1, 11, 22 })]
    [InlineData(new[] { 1 }, new[] { 0 })]
    public void Test(int[] nums, int[] expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var difference = sut.LeftRightDifference(nums);

        // Assert
        Assert.Equal(expected, difference);
    }
}