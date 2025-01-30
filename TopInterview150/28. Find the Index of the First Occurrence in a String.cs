namespace TopInterview150;

public class StrStr
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;

            if (needle.Length > haystack.Length)
                return -1;
            
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (!needle.Where((t, j) => haystack[i + j] != t).Any())
                    return i;
            }

            return -1;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var haystack = "sadbutsad";
        var needlt = "sad";
        
        // Act
        var position = sut.StrStr(haystack, needlt);
        
        // Assert
        Assert.Equal(0, position);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var haystack = "leetcode";
        var needlt = "leeto";
        
        // Act
        var position = sut.StrStr(haystack, needlt);
        
        // Assert
        Assert.Equal(-1, position);
    }
}