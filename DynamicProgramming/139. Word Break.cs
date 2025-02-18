namespace DynamicProgramming;

public sealed class WordBreak 
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (s.Length == 0) return true;
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            var worlds = new HashSet<string>(wordDict);

            for (var i = 1; i <= s.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (dp[j] && worlds.Contains(s[j .. i]))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "leetcode";
        IList<string> wordDict = ["leet","code"];
        
        // Act
        var check = sut.WordBreak(s, wordDict);
        
        // Assert
        Assert.True(check);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "applepenapple";
        IList<string> wordDict = ["apple","pen"];
        
        // Act
        var check = sut.WordBreak(s, wordDict);
        
        // Assert
        Assert.True(check);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "catsandog";
        IList<string> wordDict = ["cats","dog","sand","and","cat"];
        
        // Act
        var check = sut.WordBreak(s, wordDict);
        
        // Assert
        Assert.False(check);
    }
}