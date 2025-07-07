namespace TopInterview150;

public sealed class LongestConsecutiveSequence 
{
    public class Solution 
    {
        public int LongestConsecutive(int[] nums) 
        {
            var numbers = new HashSet<int>(nums);

            var maxSequence = 0;
            foreach(var n in numbers)
            {
                if (!numbers.Contains(n - 1))
                {
                    var currentSequence = 1;
                    var seekNumber = n;
                    while(numbers.Contains(++seekNumber))
                        currentSequence++;

                    if (maxSequence < currentSequence)
                        maxSequence = currentSequence;
                }
            }
            return maxSequence;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [100,4,200,1,3,2]; 
        
        // Act
        var longestConsecutive = sut.LongestConsecutive(nums);
        
        // Assert
        Assert.Equal(4, longestConsecutive);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,3,7,2,5,8,4,6,0,1]; 
        
        // Act
        var longestConsecutive = sut.LongestConsecutive(nums);
        
        // Assert
        Assert.Equal(9, longestConsecutive);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1,0,1,2]; 
        
        // Act
        var longestConsecutive = sut.LongestConsecutive(nums);
        
        // Assert
        Assert.Equal(3, longestConsecutive);
    }
}