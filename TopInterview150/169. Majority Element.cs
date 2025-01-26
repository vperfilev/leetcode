namespace TopInterview150;

public class MajorityElement
{
    public class Solution 
    {
        public int MajorityElement(int[] nums) 
        {
            var majorityLevel = nums.Length / 2;
            Array.Sort(nums);
            
            var count = 1;
            var current = nums[0];
            
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == current)
                {
                    count++;
                    if (count > majorityLevel)
                    {
                        break;
                    }
                }
                else
                {
                    current = nums[i];
                    count = 1;
                }
            }
            return current;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3,2,3];
        
        // Act
        var result = sut.MajorityElement(nums);
        
        // Assert
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [2,2,1,1,1,2,2];
        
        // Act
        var result = sut.MajorityElement(nums);
        
        // Assert
        Assert.Equal(2, result);
    }
}