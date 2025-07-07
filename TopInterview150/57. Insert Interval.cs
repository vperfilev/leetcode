namespace TopInterview150;

public sealed class InsertInterval 
{
    public class Solution 
    {
        public int[][] Insert(int[][] intervals, int[] newInterval) 
        {
            var merged = new List<int[]>();
            var i = 0;

            while (i < intervals.Length && intervals[i][1] < newInterval[0])
                merged.Add(intervals[i++]);

            while (i < intervals.Length && intervals[i][0] <= newInterval[1]) 
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            merged.Add(newInterval);

            while (i < intervals.Length)
                merged.Add(intervals[i++]);

            return merged.ToArray();
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] intervals = [[1,3],[6,9]];
        int[] newInterval = [2,5];
        
        // Act
        var merged = sut.Insert(intervals, newInterval);
        
        // Assert
        Assert.Equal([[1,5],[6,9]], merged);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]];
        int[] newInterval = [4,8];
        
        // Act
        var merged = sut.Insert(intervals, newInterval);
        
        // Assert
        Assert.Equal([[1,2],[3,10],[12,16]], merged);
    }
}