using Xunit;

namespace ZyfraClub._25._08;

public sealed class SumOfValuesAtIndicesWithKSetBits 
{
    public class Solution 
    {
        public int SumIndicesWithKSetBits(IList<int> nums, int k) 
        {
            var sum = 0;
            for(var i = 0; i < nums.Count; i++)
                if (CountBits(i) == k)
                    sum += nums[i];
            return sum;
        }

        private int CountBits(int n)
        {
            var count = 0;
            while (n > 0){
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
    }

    [Theory]
    [InlineData(new []{5,10,1,5,2}, 1, 13)]
    [InlineData(new []{4,3,2,1}, 2, 1)]
    public void MethodName(int[] nums, int k, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var sumIndicesWithKSetBits = sut.SumIndicesWithKSetBits(nums, k);
        
        // Assert
        Assert.Equal(expected, sumIndicesWithKSetBits);
    }
}