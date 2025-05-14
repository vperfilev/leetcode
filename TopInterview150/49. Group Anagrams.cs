namespace TopInterview150;

public sealed class GroupAnagrams
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            return strs.GroupBy(GetFreqKey)
                .Select(x => (IList<string>)x.ToList())
                .ToList();
        }

        private string GetFreqKey(string str)
        {
            var letterCount = new int[26];

            foreach (var c in str)
                letterCount[c - 'a']++;

            return string.Join(",", letterCount);
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        string[] strs = ["eat", "tea", "tan", "ate", "nat", "bat"];

        // Act
        var grouped = sut.GroupAnagrams(strs);

        // Assert
        Assert.Equal([["eat", "tea", "ate"], ["tan", "nat"], ["bat"]], grouped);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        string[] strs = [""];

        // Act
        var groupped = sut.GroupAnagrams(strs);

        // Assert
        Assert.Equal(groupped, [[""]]);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        string[] strs = ["a"];

        // Act
        var groupped = sut.GroupAnagrams(strs);

        // Assert
        Assert.Equal(groupped, [["a"]]);
    }
}