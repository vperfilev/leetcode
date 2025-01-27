namespace TopInterview150;

public class CanJump
{
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            if (nums.Length < 2) return true;
            
            var maxReach = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (maxReach < i) return false;
                var currentReach = nums[i] + i;
                if (currentReach > maxReach)
                    maxReach = currentReach;
            }

            return true;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [2,3,1,1,4];
        
        // Act
        var canJump = sut.CanJump(nums);

        // Assert
        Assert.True(canJump);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3,2,1,0,4];
        
        // Act
        var canJump = sut.CanJump(nums);

        // Assert
        Assert.False(canJump);
    }
}