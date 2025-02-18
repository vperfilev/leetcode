namespace DynamicProgramming;

public sealed class LongestPalindromicSubstring
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            var n = s.Length;
            var dp = new bool[n, n];

            for (var i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            var longest = s[ .. 1];

            for (var i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    longest = s[(i - 1) .. (i + 1)];
                    dp[i - 1, i] = true;
                }
            }

            for (var len = 3; len <= n; len++)
            {
                for (var i = 0; i <= n - len; i++)
                {
                    var j = i + len - 1;
                    if (s[i] == s[j] && dp[i +1, j - 1])
                    {
                        dp[i, j] = true;
                        if (len > longest.Length) 
                        {
                            longest = s[i .. (j+1)];
                        }
                    }
                }
            }

            return longest;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "babad";
        
        // Act
        var palindrome = sut.LongestPalindrome(s);
        
        // Assert
        Assert.Equal("bab", palindrome);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "cbbd";
        
        // Act
        var palindrome = sut.LongestPalindrome(s);
        
        // Assert
        Assert.Equal("bb", palindrome);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "bb";
        
        // Act
        var palindrome = sut.LongestPalindrome(s);
        
        // Assert
        Assert.Equal("bb", palindrome);
    }

    [Fact]
    public void Test4()
    {
        // Arrange
        var sut = new Solution();
        var s = "ccc";
        
        // Act
        var palindrome = sut.LongestPalindrome(s);
        
        // Assert
        Assert.Equal("ccc", palindrome);
    }
}