namespace TopInterview150;

public sealed class SummaryRanges 
{
    public class Solution 
    {
        public IList<string> SummaryRanges(int[] nums) 
        {
            var result = new List<string>();
            if (nums.Length == 0)
                return result;

            var rangeBegin = 0;
            for(var i = 1; i < nums.Length; i++)
            {
                if(nums[i-1] + 1 != nums[i])
                {
                    result.Add(GetRange(rangeBegin, i - 1));
                    rangeBegin = i;
                }
            }
            result.Add(GetRange(rangeBegin, nums.Length - 1));

            return result;

            string GetRange(int f, int t) => f == t ? $"{nums[t]}" : $"{nums[f]}->{nums[t]}";
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,1,2,4,5,7];
        
        // Act
        var ranges = sut.SummaryRanges(nums);
        
        // Assert
        Assert.Equal(["0->2","4->5","7"], ranges);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,2,3,4,6,8,9];
        
        // Act
        var ranges = sut.SummaryRanges(nums);
        
        // Assert
        Assert.Equal(["0","2->4","6","8->9"], ranges);
    }
}