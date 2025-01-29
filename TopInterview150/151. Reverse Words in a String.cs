namespace TopInterview150;

public class ReverseWords
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";

            var worlds = s.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(worlds);
            return string.Join(' ', worlds);
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "the sky is blue";
        
        // Act
        var reversed = sut.ReverseWords(s);
        
        // Assert
        Assert.Equal("blue is sky the", reversed);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "  hello world  ";
        
        // Act
        var reversed = sut.ReverseWords(s);
        
        // Assert
        Assert.Equal("world hello", reversed);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "a good   example";
        
        // Act
        var reversed = sut.ReverseWords(s);
        
        // Assert
        Assert.Equal("example good a", reversed);
    }
}