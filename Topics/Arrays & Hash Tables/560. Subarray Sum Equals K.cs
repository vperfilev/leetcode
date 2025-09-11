using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class SubarraySumEqualsK
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            var currentSum = 0;
            var result = 0;
            var prefixSumCount = new Dictionary<int, int> { { 0, 1 } };
            foreach (var num in nums)
            {
                currentSum += num;
                if (prefixSumCount.ContainsKey(currentSum - k)) result += prefixSumCount[currentSum - k];

                prefixSumCount[currentSum] = prefixSumCount.GetValueOrDefault(currentSum, 0) + 1;
            }

            return result;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1 }, 2, 2)]
    [InlineData(new[] { 1, 2, 3 }, 3, 2)]
    public void Test(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var subarraySum = sut.SubarraySum(nums, k);

        // Assert
        Assert.Equal(expected, subarraySum);
    }
}