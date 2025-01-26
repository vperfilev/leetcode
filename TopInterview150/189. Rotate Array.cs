namespace TopInterview150;

public class RotateArray
{
    public class Solution 
    {
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            if (nums.Length < 2 || k == 0) return;

            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int from, int to)
        {
            while (from < to)
            {
                (nums[from], nums[to]) = (nums[to], nums[from]);
                from++;
                to--;
            }
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1,2,3,4,5,6,7];
        var k = 3;
        int[] expected = [5,6,7,1,2,3,4];
        
        // Act
        sut.Rotate(nums, k);
        
        // Assert
        Assert.Equal(expected, nums);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-1,-100,3,99];
        var k = 2;
        int[] expected = [3,99,-1,-100];
        
        // Act
        sut.Rotate(nums, k);
        
        // Assert
        Assert.Equal(expected, nums);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1,2,3,4,5,6,7];
        var k = 4;
        int[] expected = [4,5,6,7,1,2,3];
        
        // Act
        sut.Rotate(nums, k);
        
        // Assert
        Assert.Equal(expected, nums);
    }
}