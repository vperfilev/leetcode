using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class SubstringWithConcatenationOfAllWords 
{
    public class Solution 
    {
        public IList<int> FindSubstring(string s, string[] words) 
        {
            var wordCount = new Dictionary<string, int>();
            foreach(var word in words)
                wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;

            var wordLen = words[0].Length;
            var stringLength = s.Length;
            var wordsCount = words.Length;
            var result = new List<int>();

            for(var i = 0; i < wordLen; i++)
            {
                int left = i, right = i;
                var windowCount = new Dictionary<string, int>();
                var count = 0;

                while(right + wordLen <= stringLength)
                {
                    var word = s[right .. (right+wordLen)];
                    right += wordLen;

                    if(wordCount.ContainsKey(word))
                    {
                        windowCount[word] = windowCount.GetValueOrDefault(word, 0) + 1;
                        count++;

                        while (windowCount[word] > wordCount[word])
                        {
                            var leftWord = s[left .. (left+wordLen)];
                            windowCount[leftWord]--;
                            left += wordLen;
                            count--;
                        }

                        if (count == wordsCount)
                        {
                            result.Add(left);
                        }
                    } 
                    else
                    {
                        left = right;
                        windowCount.Clear();
                        count = 0;
                    }
                }
            }

            return result;
        }
    }
    [Theory]
    [InlineData("barfoothefoobarman", new []{"foo","bar"}, new []{0, 9})]
    [InlineData("wordgoodgoodgoodbestword", new []{"word","good","best","word"}, new int[0])]
    [InlineData("barfoofoobarthefoobarman", new []{"bar","foo","the"}, new []{6, 9, 12})]
    public void Test(string s, string[] words, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var substrings = sut.FindSubstring(s, words).ToArray();
        Array.Sort(substrings);
        
        // Assert
        Assert.Equal(expected, substrings);
    }
}