namespace TopInterview150;

public sealed class ValidAnagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            
            var letterCount = new int[26];

            for (var i = 0; i < s.Length; i++)
            {
                letterCount[s[i] - 'a']++;
                letterCount[t[i] - 'a']--;
            }

            return letterCount.All(x => x == 0);
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "anagram";
        var t = "nagaram";

        // Act
        var isAnagram = sut.IsAnagram(s, t);

        // Assert
        Assert.True(isAnagram);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "rat";
        var t = "car";

        // Act
        var isAnagram = sut.IsAnagram(s, t);

        // Assert
        Assert.False(isAnagram);
    }
}