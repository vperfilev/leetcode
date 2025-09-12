using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class FirstMissingPositive 
{
    public class Solution 
    {
        public int FirstMissingPositive(int[] nums) 
        {
            var n = nums.Length;
            for (var i = 0; i < n; i++)
                while(nums[i] < n && nums[i] > 0 && nums[i] != nums[nums[i] - 1])
                    (nums[nums[i] - 1], nums[i]) = (nums[i], nums[nums[i] - 1]);

            for(var i = 0; i < n; i++)
                if (nums[i] != i + 1)
                    return i + 1;
            return n + 1;
            
        }
    }
    
    [Theory]
    [InlineData(new []{1,2,0}, 3)]
    [InlineData(new []{3,4,-1,1}, 2)]
    [InlineData(new []{7,8,9,11,12}, 1)]
    public void Test(int[] nums, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var firstMissingPositive = sut.FirstMissingPositive(nums);
        
        // Assert
        Assert.Equal(expected, firstMissingPositive);
    }
}