using Xunit;

namespace ZyfraClub._25._06;

public sealed class CountPairsWhoseSumIsLessThanTarget
{
    public class Solution
    {
        public int CountPairs(IList<int> nums, int target)
        {
            var pairsCount = 0;
            for (var i = 0; i < nums.Count - 1; i++)
            for (var j = i + 1; j < nums.Count; j++)
                if (nums[i] + nums[j] < target)
                    pairsCount++;

            return pairsCount;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-1, 1, 2, 3, 1];
        var target = 2; 
        
        // Act
        var pairCount = sut.CountPairs(nums, target);
        
        // Assert
        Assert.Equal(3, pairCount);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-6,2,5,-2,-7,-1,3];
        var target = -2; 
        
        // Act
        var pairCount = sut.CountPairs(nums, target);
        
        // Assert
        Assert.Equal(10, pairCount);
    }
}