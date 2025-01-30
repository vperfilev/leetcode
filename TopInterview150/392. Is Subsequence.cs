namespace TopInterview150;

public class IsSubsequence
{
    public class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            var sPos = 0;
            var tPos = 0;

            while (sPos < s.Length && tPos < t.Length)
                if (t[tPos++] == s[sPos])
                    sPos++;

            return sPos == s.Length;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "abc";
        var t = "ahbgdc";
        
        // Act
        var isSubsequence = sut.IsSubsequence(s, t);
        
        // Assert
        Assert.True(isSubsequence);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "axc";
        var t = "ahbgdc";
        
        // Act
        var isSubsequence = sut.IsSubsequence(s, t);
        
        // Assert
        Assert.False(isSubsequence);
    }
}