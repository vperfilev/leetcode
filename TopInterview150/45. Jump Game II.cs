namespace TopInterview150;

public class JumpGameII
{
    public class Solution
    {
        public int Jump(int[] nums)
        {
            var currentEnd = 0;
            var farthest = 0;
            var jumps = 0;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, nums[i] + i);
                
                if (i == currentEnd)
                {
                    jumps++;
                    currentEnd = farthest;
                    
                    if (currentEnd >= nums.Length - 1)
                        break;
                }

            }
            
            return jumps;
        }
        
        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new Solution();
            int[] nums = [2,3,1,1,4];
        
            // Act
            var jumpCount = sut.Jump(nums);

            // Assert
            Assert.Equal(2, jumpCount);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var sut = new Solution();
            int[] nums = [2,3,0,1,4];
        
            // Act
            var jumpCount = sut.Jump(nums);

            // Assert
            Assert.Equal(2, jumpCount);
        }
    }
}