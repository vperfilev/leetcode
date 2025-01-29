namespace TopInterview150;

public class LengthOfLastWord
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            var pos = s.Length - 1;
            var worldLen = 0;
            
            while (pos >= 0 && s[pos] == ' ') pos--;

            while (pos >= 0 && s[pos] != ' ')
            {
                pos--;
                worldLen++;
            }

            return worldLen;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "Hello World";
        
        // Act
        var len = sut.LengthOfLastWord(s);
        
        // Assert
        Assert.Equal(5, len);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "   fly me   to   the moon  ";
        
        // Act
        var len = sut.LengthOfLastWord(s);
        
        // Assert
        Assert.Equal(4, len);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "luffy is still joyboy";
        
        // Act
        var len = sut.LengthOfLastWord(s);
        
        // Assert
        Assert.Equal(6, len);
    }    
    [Fact]
    public void Test4()
    {
        // Arrange
        var sut = new Solution();
        var s = "a";
        
        // Act
        var len = sut.LengthOfLastWord(s);
        
        // Assert
        Assert.Equal(1, len);
    }
}