using Xunit;

namespace ZyfraClub._25._07;

public sealed class MinimumOperationsToCollectElements 
{
    public class Solution
    {
        public int MinOperations(IList<int> nums, int k)
        {
            ulong mask = (1UL << k) - 1;
            int i;
            for (i = nums.Count - 1; i >= 0; i--)
            {
                mask &= ~(1UL << nums[i] - 1);
                if (mask == 0UL)
                    return nums.Count - i;
            }

            return nums.Count;
        }
    }

    [Theory]
    [InlineData(new[] { 3, 1, 5, 4, 2 }, 2, 4)]
    [InlineData(new[] { 3, 1, 5, 4, 2 }, 5, 5)]
    [InlineData(new[] { 3, 2, 5, 3, 1 }, 3, 4)]
    public void Test(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var minOperations = sut.MinOperations(nums, k);

        // Assert
        Assert.Equal(expected, minOperations);
    }
}