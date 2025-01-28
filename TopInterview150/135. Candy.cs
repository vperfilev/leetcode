namespace TopInterview150;

public class Candy
{
    public class Solution
    {
        public int Candy(int[] ratings)
        {
            var childrenCount = ratings.Length;
            var candies = new int[childrenCount];
            candies[0] = 1;

            for (var i = 1; i < childrenCount; i++)
            {
                candies[i] = ratings[i] > ratings[i - 1] ? candies[i - 1] + 1 : 1;
            }

            for (var i = childrenCount - 2; i >= 0; i--)
            {
                candies[i] = Math.Max(candies[i], (ratings[i] > ratings[i + 1] ? candies[i + 1] + 1 : 1));
            }

            return candies.Sum();
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] ratings = [1,0,2];

        // Act
        var candyCount = sut.Candy(ratings);
        
        // Assert
        Assert.Equal(5, candyCount);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] ratings = [1,2,2];

        // Act
        var candyCount = sut.Candy(ratings);
        
        // Assert
        Assert.Equal(4, candyCount);
    }
}