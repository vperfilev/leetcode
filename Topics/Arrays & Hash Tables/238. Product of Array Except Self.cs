using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class ProductOfArrayExceptSelf 
{
    public class Solution {
        public int[] ProductExceptSelf(int[] nums) 
        {
            var zeroIndex = 0;
            var zeroCount = 0;
            var total = 1;

            for(var i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    zeroCount++;
                    zeroIndex = i;
                }
                else
                    total *= nums[i];
            }
        
            if (zeroCount == 0)
                return nums.Select(x => total / x).ToArray();
        
            var result = new int[nums.Length];
            if (zeroCount == 1)
                result[zeroIndex] = total;

            return result;
        }
    }

    [Theory]
    [InlineData(new []{1,2,3,4}, new[]{24,12,8,6})]
    [InlineData(new []{-1,1,0,-3,3}, new[]{0,0,9,0,0})]
    public void Test(int[] nums, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var productExceptSelf = sut.ProductExceptSelf(nums);

        // Assert
        Assert.Equal(expected, productExceptSelf);
    }
}