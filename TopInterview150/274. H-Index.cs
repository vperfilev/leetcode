namespace TopInterview150;

public class HIndex
{
    public class Solution
    {
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            Array.Reverse(citations);

            var hIndex = 0;
            var i = 0;
            while (i < citations.Length && citations[i] >= i + 1)
            {
                hIndex++;
                i++;
            }

            return hIndex;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [3,0,6,1,5];
        
        // Act
        var hIndex = sut.HIndex(nums);

        // Assert
        Assert.Equal(3, hIndex);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [1,3,1];
        
        // Act
        var hIndex = sut.HIndex(nums);

        // Assert
        Assert.Equal(1, hIndex);
    }
}