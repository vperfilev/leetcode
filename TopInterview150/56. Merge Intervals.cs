namespace TopInterview150;

public sealed class MergeIntervals 
{
    public class Solution 
    {
        public int[][] Merge(int[][] intervals) 
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var merged = new List<int[]>();
            var (start, end) = (intervals[0][0], intervals[0][1]);

            foreach(var interval in intervals.Skip(1))
            {
                if (interval[0] <= end)
                {
                    end = Math.Max(end, interval[1]);
                }
                else
                {
                    merged.Add([start, end]);
                    (start, end) = (interval[0], interval[1]);
                }
            }

            merged.Add([start, end]);
            return merged.ToArray();
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] intervals = [[1,3],[2,6],[8,10],[15,18]];
        
        // Act
        var merged = sut.Merge(intervals);

        // Assert
        Assert.Equal([[1,6],[8,10],[15,18]], merged);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] intervals = [[1,4],[4,5]];
        
        // Act
        var merged = sut.Merge(intervals);

        // Assert
        Assert.Equal([[1,5]], merged);
    }
}