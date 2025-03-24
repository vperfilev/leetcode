namespace TopInterview150;

public class RansomNote
{
    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Span<int> lettersCount = stackalloc int[26];

            foreach (var letter in magazine)
                lettersCount[letter - 'a']++;

            foreach (var letter in ransomNote)
                if (--lettersCount[letter - 'a'] < 0)
                    return false;
            return true;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var ransomNote = "a";
        var magazine = "b";
        
        // Act
        var canConstruct = sut.CanConstruct(ransomNote, magazine);
        
        // Assert
        Assert.False(canConstruct);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var ransomNote = "aa";
        var magazine = "ab";
        
        // Act
        var canConstruct = sut.CanConstruct(ransomNote, magazine);
        
        // Assert
        Assert.False(canConstruct);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var ransomNote = "aa";
        var magazine = "aab";
        
        // Act
        var canConstruct = sut.CanConstruct(ransomNote, magazine);
        
        // Assert
        Assert.True(canConstruct);
    }
}