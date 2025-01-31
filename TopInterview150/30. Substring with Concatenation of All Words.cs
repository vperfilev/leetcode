namespace TopInterview150;

public class FindSubstring
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();

            if (words.Length == 0 || s.Length < words.Length * words[0].Length)
                return result;
            
            var worldLen = words[0].Length;
            var totalLen = worldLen * words.Length;

            var wordsCount = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            for (var i = 0; i <= s.Length - totalLen; i++)
            {
                var localWordsCount = new Dictionary<string, int>(wordsCount);
                for (var j = i; j < i+ totalLen; j += worldLen)
                {
                    var word = s[j .. (j + worldLen)];
                    if (!localWordsCount.TryGetValue(word, out var c) || c == 0)
                    {
                        break;
                    }

                    localWordsCount[word]--;
                }
                if (localWordsCount.All(x => x.Value == 0))
                    result.Add(i);
            }

            return result;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "barfoothefoobarman";
        string[] worlds = ["foo","bar"];
        
        // Act
        var substring = sut.FindSubstring(s, worlds);
        
        // Assert
        Assert.Equal([0,9], substring);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "wordgoodgoodgoodbestword";
        string[] worlds = ["word","good","best","word"];
        
        // Act
        var substring = sut.FindSubstring(s, worlds);
        
        // Assert
        Assert.Equal([], substring);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "barfoofoobarthefoobarman";
        string[] worlds = ["bar","foo","the"];
        
        // Act
        var substring = sut.FindSubstring(s, worlds);
        
        // Assert
        Assert.Equal([6,9,12], substring);
    }
    
    [Fact]
    public void Test4()
    {
        // Arrange
        var sut = new Solution();
        var s = "wordgoodgoodgoodbestword";
        string[] worlds = ["word","good","best","good"];
        
        // Act
        var substring = sut.FindSubstring(s, worlds);
        
        // Assert
        Assert.Equal([8], substring);
    }
}