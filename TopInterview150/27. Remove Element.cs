namespace TopInterview150;

public class RemoveElement
{
    public class Solution 
    {
        public int RemoveElement(int[] nums, int val) 
        {
            var i = -1;
            var j = 0;
            while (j < nums.Length)
            {
                if (nums[j] == val)
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
        int[] nums = [3,2,2,3];
        var val = 3;
        
        // Act
        var result = sut.RemoveElement(nums, val);
        
        // Assert
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,1,2,2,3,0,4,2];
        var val = 2;
        
        // Act
        var result = sut.RemoveElement(nums, val);
        
        // Assert
        Assert.Equal(5, result);
    }
}