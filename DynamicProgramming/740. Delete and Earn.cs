namespace DynamicProgramming;

public sealed class DeleteAndEarn 
{
    public class Solution
    {
        public int DeleteAndEarn(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var max = nums.Max();

            var points = new int[max + 1];

            foreach (var num in nums) points[num] += num;

            var dp = new int[max + 1];

            dp[0] = 0;
            dp[1] = points[1];

            for (var i = 2; i <= max; i++) 
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + points[i]);
            return dp[max];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3, 4, 2];
        
        // Act
        var result = sut.DeleteAndEarn(nums);
        
        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [2,2,3,3,3,4];
        
        // Act
        var result = sut.DeleteAndEarn(nums);
        
        // Assert
        Assert.Equal(9, result);
    }
}