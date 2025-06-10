namespace TopInterview150;

public sealed class ContainsDuplicate2 
{
    public class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var numberWindow = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (!numberWindow.Add(nums[i]))
                    return true;

                var indexToRemove = i - k;
                if (indexToRemove >= 0)
                    numberWindow.Remove(nums[indexToRemove]);
            }

            return false;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        int[] nums = [1, 2, 3, 1];
        var k = 3;
        var result = sut.ContainsNearbyDuplicate(nums, k);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        int[] nums = [1,0,1,1];
        var k = 1;
        var result = sut.ContainsNearbyDuplicate(nums, k);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        int[] nums = [1,2,3,1,2,3];
        var k = 2;
        var result = sut.ContainsNearbyDuplicate(nums, k);
        
        // Assert
        Assert.False(result);
    }
}