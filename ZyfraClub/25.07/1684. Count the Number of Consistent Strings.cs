using Xunit;

namespace ZyfraClub._25._07;

public sealed class CountTheNumberOfConsistentStrings 
{
    public class Solution 
    {
        public int CountConsistentStrings(string allowed, string[] words) 
        {
            var allowedChars = new HashSet<char>(allowed.Select(x => x));
            return words.Count(word => word.All(c => allowedChars.Contains(c)));
        }
    }

    [Theory]
    [InlineData("ab", new[]{"ad","bd","aaab","baa","badab"}, 2)]
    [InlineData("abc", new[]{"a","b","c","ab","ac","bc","abc"}, 7)]
    [InlineData("cad", new[]{"cc","acd","b","ba","bac","bad","ac","d"}, 4)]
    public void Test(string allowed, string[] worlds, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var consistentCount = sut.CountConsistentStrings(allowed, worlds);
        
        // Assert
        Assert.Equal(expected, consistentCount);
    }
}