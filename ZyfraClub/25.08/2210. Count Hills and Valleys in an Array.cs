using Xunit;

namespace ZyfraClub._25._08;

public sealed class CountHillsAndValleysInAnArray 
{
    public class Solution 
    {
        public int CountHillValley(int[] nums) 
        {
            var count = 0;
            var prevSign = 0;

            for(var i = 1; i < nums.Length; i++)
            {
                var change = nums[i] - nums[i - 1];
                if (change == 0) continue;

                var sign = Math.Sign(change);
                if (prevSign != 0 && prevSign != sign) count++;
                prevSign = sign;
            }
            return count;    
        }
    }

    [Theory]
    [InlineData(new[] {2,4,1,1,6,5}, 3)]
    [InlineData(new[] {6,6,5,5,4,1}, 0)]
    public void Test(int[] nums, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var countHillValley = sut.CountHillValley(nums);
        
        // Assert
        Assert.Equal(expected, countHillValley);
    }
}