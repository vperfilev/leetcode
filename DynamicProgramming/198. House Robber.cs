namespace DynamicProgramming;

public sealed class HouseRobber
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var prev1 = 0;
            var prev2 = 0;

            foreach (var num in nums)
            {
                var tmp = prev1;
                prev1 = Math.Max(prev2 + num, prev1);
                prev2 = tmp;
            }

            return prev1;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1, 2, 3, 1];
        
        // Act
        var rob = sut.Rob(nums);
        
        // Assert
        Assert.Equal(4, rob);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [2,7,9,3,1];
        
        // Act
        var rob = sut.Rob(nums);
        
        // Assert
        Assert.Equal(12, rob);
    }
}