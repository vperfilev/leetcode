namespace TopInterview150;

public sealed class IsomorphicStrings
{
    public class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            Span<char> sToT = stackalloc char[256];
            Span<char> tToS = stackalloc char[256];

            for (var i = 0; i < s.Length; i++)
            {
                var sChar = s[i];
                var tChar = t[i];
                
                if (sToT[sChar] == 0)
                    sToT[sChar] = tChar;
                else if (sToT[sChar] != tChar)
                    return false;
                
                if (tToS[tChar] == 0)
                    tToS[tChar] = sChar;
                else if (tToS[tChar] != sChar)
                    return false;
            }
            return true;
        }
    }
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "egg";
        var t = "add";
        
        // Act
        var isIsomorphic = sut.IsIsomorphic(s, t);

        // Assert
        Assert.True(isIsomorphic);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "foo";
        var t = "bar";
        
        // Act
        var isIsomorphic = sut.IsIsomorphic(s, t);

        // Assert
        Assert.False(isIsomorphic);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "paper";
        var t = "title";
        
        // Act
        var isIsomorphic = sut.IsIsomorphic(s, t);

        // Assert
        Assert.True(isIsomorphic);
    }
    
    [Fact]
    public void Test4()
    {
        // Arrange
        var sut = new Solution();
        var s = "badc";
        var t = "baba";
        
        // Act
        var isIsomorphic = sut.IsIsomorphic(s, t);

        // Assert
        Assert.False(isIsomorphic);
    }

}