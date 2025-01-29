namespace TopInterview150;

public class TrappingWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height.Length < 2)
                return 0;

            var left = 0;
            var right = height.Length - 1;

            var leftMax = 0;
            var rightMax = 0;

            var trappedWater = 0;
            
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (leftMax < height[left])
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        trappedWater += leftMax - height[left];
                    }     
                    left++;
                }
                else
                {
                    if (rightMax < height[right])
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        trappedWater += rightMax - height[right];
                    }

                    right--;
                }
            }

            return trappedWater;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] height = [0,1,0,2,1,0,1,3,2,1,2,1];
        
        // Act
        var trapped = sut.Trap(height);

        // Assert
        Assert.Equal(6, trapped);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] height = [4,2,0,3,2,5];
        
        // Act
        var trapped = sut.Trap(height);

        // Assert
        Assert.Equal(9, trapped);
    }
}