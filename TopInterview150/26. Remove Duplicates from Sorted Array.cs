namespace TopInterview150;

public class RemoveDuplicates
{
    public class Solution 
    {
        public int RemoveDuplicates(int[] nums)
        {
            var i = 0;
            var j = 1;
            while (j < nums.Length)
            {
                if (nums[i] == nums[j])
                {
                    j++;
                }
                else
                {
                    nums[++i] = nums[j++];
                }
            }

            return ++i;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1, 1, 2];
        
        // Act
        var result = sut.RemoveDuplicates(nums);
        
        // Assert
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,0,1,1,1,2,2,3,3,4];
        
        // Act
        var result = sut.RemoveDuplicates(nums);
        
        // Assert
        Assert.Equal(5, result);
    }
}