using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class MissingNumber 
{
    public class Solution 
    {
        public int MissingNumber(int[] nums) 
        {
            var result = 0;
            for(var i = 0; i < nums.Length; i++)
                result ^= i ^ nums[i];

            return result^nums.Length;
        }
    }    
    
    [Theory]
    [InlineData(new []{3,0,1}, 2)]
    [InlineData(new []{0,1}, 2)]
    [InlineData(new []{9,6,4,2,3,5,7,0,1}, 8)]
    public void Test(int[] nums, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var missingNumber = sut.MissingNumber(nums);

        // Assert
        Assert.Equal(expected, missingNumber);
    }
}