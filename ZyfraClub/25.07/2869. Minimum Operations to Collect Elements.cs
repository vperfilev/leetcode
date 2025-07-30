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

    /*
Example 1:

Input: nums = [3,1,5,4,2], k = 2
Output: 4
Explanation: After 4 operations, we collect elements 2, 4, 5, and 1, in this order. Our collection contains elements 1 and 2. Hence, the answer is 4.
Example 2:

Input: nums = [3,1,5,4,2], k = 5
Output: 5
Explanation: After 5 operations, we collect elements 2, 4, 5, 1, and 3, in this order. Our collection contains elements 1 through 5. Hence, the answer is 5.
Example 3:

Input: nums = [3,2,5,3,1], k = 3
Output: 4
Explanation: After 4 operations, we collect elements 1, 3, 5, and 2, in this order. Our collection contains elements 1 through 3. Hence, the answer is 4.
     */

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