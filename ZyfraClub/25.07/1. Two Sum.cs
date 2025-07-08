using Xunit;

namespace ZyfraClub._25._07;

public class TwoSum 
{
    public class Solution 
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var compliments = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var compliment = target - nums[i];
                if (compliments.TryGetValue(compliment, out var index))
                {
                    return [index, i];
                }

                compliments[nums[i]] = i;
            }

            return [];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [2,7,11,15];
        var target = 9;
        
        // Act
        var indexes = sut.TwoSum(nums, target);
        
        // Assert
        Assert.Equal([0,1], indexes);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3,2,4];
        var target = 6;
        
        // Act
        var indexes = sut.TwoSum(nums, target);
        
        // Assert
        Assert.Equal([1,2], indexes);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3,3];
        var target = 6;
        
        // Act
        var indexes = sut.TwoSum(nums, target);
        
        // Assert
        Assert.Equal([0,1], indexes);
    }
}