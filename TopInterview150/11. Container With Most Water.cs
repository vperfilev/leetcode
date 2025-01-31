namespace TopInterview150;

public class ContainerWithMostWater
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height.Length < 2) return 0;

            var left = 0;
            var right = height.Length - 1;
            var maxArea = 0;
            
            while (left < right)
            {
                var leftHeight = height[left];
                var rightHeight = height[right];
                var area = Math.Min(leftHeight, rightHeight) * (right - left);
                if (maxArea < area) maxArea = area;
                if (leftHeight < rightHeight)
                {
                    left++;
                }
                else
                {
                    right--;
                }
                
            }

            return maxArea;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] height = [1,8,6,2,5,4,8,3,7];
        
        // Act
        var volume = sut.MaxArea(height);
        
        // Assert
        Assert.Equal(49, volume);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] height = [1,1];
        
        // Act
        var volume = sut.MaxArea(height);
        
        // Assert
        Assert.Equal(1, volume);
    }
}