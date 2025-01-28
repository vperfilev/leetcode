namespace TopInterview150;

public class ProductExceptSelf
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            var rowValue = 1;
            
            for (var i = 0; i < nums.Length; i++)
            {
                result[i] = rowValue;
                rowValue *= nums[i];
            }

            rowValue = 1;
            for (var i = nums.Length - 1 ; i >= 0; i--)
            {
                result[i] *= rowValue;
                rowValue *= nums[i];
            }

            return result;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1, 2, 3, 4];
        
        // Act
        var result = sut.ProductExceptSelf(nums);
        
        // Assert
        int[] expected = [24, 12, 8, 6]; 
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-1,1,0,-3,3];
        
        // Act
        var result = sut.ProductExceptSelf(nums);
        
        // Assert
        int[] expected = [0,0,9,0,0]; 
        Assert.Equal(expected, result);
    }
}