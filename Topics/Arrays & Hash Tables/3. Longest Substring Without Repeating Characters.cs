using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class LongestSubstringWithoutRepeatingCharacters 
{
    public class Solution 
    {
        public int LengthOfLongestSubstring(string s) 
        {
            var maxLength = 0;
            var symbols = new HashSet<char>();
            for(int left = 0, right = 0; right < s.Length; right++)
            {
                while(!symbols.Add(s[right]))
                {
                    symbols.Remove(s[left++]);
                }
                maxLength = Math.Max(maxLength, symbols.Count);
            } 
            return maxLength;   
        }
    }
    
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    public void Test(string s, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var lengthOfLongestSubstring = sut.LengthOfLongestSubstring(s);
        
        // Assert
        Assert.Equal(expected, lengthOfLongestSubstring);
    }
}