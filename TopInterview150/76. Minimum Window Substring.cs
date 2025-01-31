namespace TopInterview150;

public class MinimumWindowSubstring
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (t.Length > s.Length || t.Length == 0 || s.Length == 0)
                return "";

            var tCount = t.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var left = 0;
            var windowCount = new Dictionary<char, int>();
            var minWindowIndex = int.MaxValue;
            var minWindowLength = int.MaxValue;

            for (var right = 0; right < s.Length; right++)
            {
                var letter = s[right];
                windowCount[letter] = windowCount.TryGetValue(letter, out var value) ? value + 1: 1;

                while (IsSolution(tCount, windowCount))
                {
                    if (minWindowLength > right - left + 1)
                    {
                        minWindowLength = right - left + 1;
                        minWindowIndex = left;
                    }
                    
                    if (windowCount[s[left]] > 1)
                        windowCount[s[left]]--;
                    else
                        windowCount.Remove(s[left]);                        
                    
                    left++;
                }
            }
            
            return minWindowIndex == int.MaxValue ? "" : s.Substring(minWindowIndex, minWindowLength);
        }
        
        private bool IsSolution(IDictionary<char, int> required, IDictionary<char, int> current) => 
            required.All(p => current.ContainsKey(p.Key) && current[p.Key] >= p.Value);
    }
    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "ADOBECODEBANC";
        var t = "ABC";
        
        // Act
        var minWindow = sut.MinWindow(s, t);
        
        // Assert
        Assert.Equal("BANC", minWindow);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "a";
        var t = "a";
        
        // Act
        var minWindow = sut.MinWindow(s, t);
        
        // Assert
        Assert.Equal("a", minWindow);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = "a";
        var t = "aa";
        
        // Act
        var minWindow = sut.MinWindow(s, t);
        
        // Assert
        Assert.Equal("", minWindow);
    }
}