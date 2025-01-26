namespace TopInterview150;

public class RemoveDuplicatesII
{
    public class Solution {
        public int RemoveDuplicates(int[] nums) 
        {
            if (nums.Length < 3) return nums.Length;
            
            var i = 1;
            var j = 2;
            while (j < nums.Length)
            {
                if (nums[i] == nums[j] && nums[i] == nums[i - 1])
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
        int[] nums = [1,1,1,2,2,3];
        
        // Act
        var result = sut.RemoveDuplicates(nums);
        
        // Assert
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,0,1,1,1,1,2,3,3];
        
        // Act
        var result = sut.RemoveDuplicates(nums);
        
        // Assert
        Assert.Equal(7, result);
    }
}