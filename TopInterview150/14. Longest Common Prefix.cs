using Microsoft.VisualBasic;

namespace TopInterview150;

public class LongestCommonPrefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";


            for (var i = 0; i < strs[0].Length; i++)
            {
                var letter = strs[0][i];
                
                for (var j = 1; j < strs.Length; j++)
                {
                    var str = strs[j];
                    if (str.Length <= i || str[i] != letter)
                        return str[..i];
                }
            }

            return strs[0];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        string[] strings = ["flower","flow","flight"];
        
        // Act
        var prefix = sut.LongestCommonPrefix(strings);
        
        // Assert
        Assert.Equal("fl", prefix);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        string[] strings = ["dog","racecar","car"];
        
        // Act
        var prefix = sut.LongestCommonPrefix(strings);
        
        // Assert
        Assert.Equal("", prefix);
    }
}