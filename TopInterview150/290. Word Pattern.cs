namespace TopInterview150;

public class WordPattern
{
    public class Solution
    {
        public bool WordPattern(string pattern, string s)
        {
            var words = s.Split(' ');
            
            if (words.Length != pattern.Length)
                return false;
            
            var charToWord = new Dictionary<char, string>();
            var wordToChar = new Dictionary<string, char>();
            
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var patternSymbol = pattern[i];

                if (charToWord.TryGetValue(patternSymbol, out var w))
                {
                    if (word != w) return false;
                }
                else
                {
                    if (wordToChar.TryGetValue(word, out var c) && c != patternSymbol)
                        return false;
                    
                    wordToChar[word] = patternSymbol;
                    charToWord[patternSymbol] = word;
                }
            }
            return true;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var solution = new Solution();
     
        var pattern = "abba";
        var s = "dog cat cat dog";
        
        // Act
        var matched = solution.WordPattern(pattern, s);
        
        // Assert
        Assert.True(matched);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var solution = new Solution();
        
        var pattern = "abba";
        var s = "dog cat cat fish";
        
        // Act
        var matched = solution.WordPattern(pattern, s);
        
        // Assert
        Assert.False(matched);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var solution = new Solution();
        
        var pattern = "aaaa";
        var s = "dog cat cat dog";
        
        // Act
        var matched = solution.WordPattern(pattern, s);
        
        // Assert
        Assert.False(matched);
    }
    
    [Fact]
    public void Test4()
    {
        // Arrange
        var solution = new Solution();
        
        var pattern = "abba";
        var s = "dog dog dog dog";
        
        // Act
        var matched = solution.WordPattern(pattern, s);
        
        // Assert
        Assert.False(matched);
    }
}