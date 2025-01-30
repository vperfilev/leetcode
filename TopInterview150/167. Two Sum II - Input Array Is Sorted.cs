namespace TopInterview150;

public class TwoSumII
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                var sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return [++left, ++right];
                }

                if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return [];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] numbers = [2,7,11,15];
        var target = 9;
        
        // Act
        var indexes = sut.TwoSum(numbers, target);
        
        // Assert
        Assert.Equal([1,2], indexes);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] numbers = [2,3,4];
        var target = 6;
        
        // Act
        var indexes = sut.TwoSum(numbers, target);
        
        // Assert
        Assert.Equal([1,3], indexes);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] numbers = [-1,0];
        var target = -1;
        
        // Act
        var indexes = sut.TwoSum(numbers, target);
        
        // Assert
        Assert.Equal([1,2], indexes);
    }
}