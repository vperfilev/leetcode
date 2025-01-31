namespace TopInterview150;

public class MinimumSizeSubarraySum
{
    public class Solution
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            var left = 0;
            var sum = 0;
            var minLength = int.MaxValue;
            
            for (var right = 0; right < nums.Length; right++)
            {
                sum += nums[right];

                while (sum >= target)
                {
                    minLength = Math.Min(minLength, (right - left + 1));
                    sum -= nums[left++];
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var target = 7;
        int[] nums = [2,3,1,2,4,3];
        
        // Act
        var length = sut.MinSubArrayLen(target, nums);
        
        // Assert
        Assert.Equal(2, length);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var target = 4;
        int[] nums = [1,4,4];
        
        // Act
        var length = sut.MinSubArrayLen(target, nums);
        
        // Assert
        Assert.Equal(1, length);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var target = 11;
        int[] nums = [1,1,1,1,1,1,1,1];
        
        // Act
        var length = sut.MinSubArrayLen(target, nums);
        
        // Assert
        Assert.Equal(0, length);
    }
}