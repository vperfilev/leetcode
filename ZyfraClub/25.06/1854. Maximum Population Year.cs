using Xunit;

namespace ZyfraClub._25._06;

public sealed class MaximumPopulationYear 
{
    public class Solution
    {
        public int MaximumPopulation(int[][] logs)
        {
            const int begin = 1950;
            const int end = 2050;
            const int range = end - begin + 1;

            Span<int> populationChange = stackalloc int[range];

            foreach (var log in logs)
            {
                populationChange[log[0] - begin]++;
                populationChange[log[1] - begin]--;
            }

            var bestYear = begin;
            var maxPopulation = populationChange[0];
            var current = populationChange[0];
            for (var i = 1; i < populationChange.Length; i++)
            {
                current += populationChange[i];
                if (current > maxPopulation)
                {
                    bestYear = i + begin;
                    maxPopulation = current;
                }
            }

            return bestYear;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[][] logs = [[1993, 1999], [2000, 2010]];
        
        // Act
        var maxPopulation = sut.MaximumPopulation(logs);
        
        // Assert
        Assert.Equal(1993, maxPopulation);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[][] logs = [[1950, 1961], [1960, 1971], [1970, 1981]];
        
        // Act
        var maxPopulation = sut.MaximumPopulation(logs);
        
        // Assert
        Assert.Equal(1960, maxPopulation);
    } }