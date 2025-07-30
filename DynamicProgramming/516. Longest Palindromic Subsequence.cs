using System.Diagnostics;

namespace DynamicProgramming;

public sealed class LongestPalindromicSubsequence 
{
    public class Solution
    {
        public int LongestPalindromeSubseq(string s)
        {
            var n = s.Length;
            var dp = new bool[n, n];
            var longest = 1;
            
            for (var i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            for (var i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    longest = 2;
                    dp[i - 1, i] = true;
                }
            }

            for (var len = 3; len <= n; len++)
            {
                for (var i = 0; i <= n - len; i++)
                {
                    var j = i + len - 1;
                    if (s[j] == s[i] && dp[i + 1, j - 1])
                    {
                        longest = len;
                        dp[i, j] = true;
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
        var s = "bbbab";
        
        // Act
        var length = sut.LongestPalindromeSubseq(s);
        
        // Assert
        Assert.Equal(3, length);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "cbbd";
        
        // Act
        var length = sut.LongestPalindromeSubseq(s);
        
        // Assert
        Assert.Equal(2, length);
    }
}