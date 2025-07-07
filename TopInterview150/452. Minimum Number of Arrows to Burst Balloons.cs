namespace TopInterview150;

public sealed class MinimumNumberOfArrowsToBurstBalloons 
{
    public class Solution {
        public int FindMinArrowShots(int[][] points) 
        {
            Array.Sort(points, (a,b) => a[1].CompareTo(b[1]));
            var arrows = 1;
            var lastArrow = points[0][1];
            for(var i = 1; i < points.Length; i++)
            {
                if(points[i][0] > lastArrow)
                {
                    arrows++;
                    lastArrow = points[i][1];
                }
            }

            return arrows;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] points = [[10,16],[2,8],[1,6],[7,12]];
        
        // Act
        var arrows = sut.FindMinArrowShots(points);
        
        // Assert
        Assert.Equal(2, arrows);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] points = [[1,2],[3,4],[5,6],[7,8]];
        
        // Act
        var arrows = sut.FindMinArrowShots(points);
        
        // Assert
        Assert.Equal(4, arrows);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[][] points = [[1,2],[2,3],[3,4],[4,5]];
        
        // Act
        var arrows = sut.FindMinArrowShots(points);
        
        // Assert
        Assert.Equal(2, arrows);
    }
}