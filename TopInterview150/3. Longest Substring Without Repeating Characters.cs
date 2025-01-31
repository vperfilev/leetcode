namespace TopInterview150;

public class LengthOfLongestSubstring
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var letterPositions = new Dictionary<char, int>();
            var left = 0;
            var maxLength = 0;

            for (var right = 0; right < s.Length; right++)
            {
                var currentChar = s[right];

                if (letterPositions.TryGetValue(currentChar, out var position))
                    left = Math.Max(left, ++position);

                letterPositions[currentChar] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "abcabcbb";
        
        // Act
        var length = sut.LengthOfLongestSubstring(s);
        
        // Assert
        Assert.Equal(3, length);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "bbbbb";
        
        // Act
        var length = sut.LengthOfLongestSubstring(s);
        
        // Assert
        Assert.Equal(1, length);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "pwwkew";
        
        // Act
        var length = sut.LengthOfLongestSubstring(s);
        
        // Assert
        Assert.Equal(3, length);
    }
    
    [Fact]
    public void Test4()
    {
        // Arrange
        var sut = new Solution();
        var s = "abba";
        
        // Act
        var length = sut.LengthOfLongestSubstring(s);
        
        // Assert
        Assert.Equal(2, length);
    }
}