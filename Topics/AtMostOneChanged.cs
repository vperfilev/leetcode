using Xunit;

namespace Topics;

public sealed class AtMostOneChanged
{
    public bool IsAtMostOneChange(string a, string b)
    {
        var (shorter, longer) = a.Length < b.Length ? (a, b) : (b, a);
        var diff = longer.Length - shorter.Length;
        if (diff > 1) return false;
        
        var l = 0;
        var r = shorter.Length;
        while (l < r && shorter[l] == longer[l]) l++;
        while (l < r && shorter[r - 1] == longer[r - 1 + diff]) r--;
        
        return diff == 0 ? (r - l) <= 1 : (r - l) == 0;
    }
    
    [Theory]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("abc", "abc", true)]
    [InlineData("aaaa", "aaaa", true)]
    [InlineData("", "ab", false)]
    [InlineData("a", "abc", false)]
    [InlineData("abc", "", false)]
    [InlineData("abcd", "a", false)]
    [InlineData("bc", "abc", true)]
    [InlineData("", "a", true)]
    [InlineData("ac", "abc", true)]
    [InlineData("ab", "acb", true)]
    [InlineData("ab", "abc", true)]
    [InlineData("a", "ab", true)]
    [InlineData("abc", "bc", true)]
    [InlineData("abc", "ac", true)]
    [InlineData("abc", "ab", true)]
    [InlineData("xbc", "abc", true)]
    [InlineData("axc", "abc", true)]
    [InlineData("abx", "abc", true)]
    [InlineData("a", "b", true)]
    [InlineData("cab", "acb", false)]
    [InlineData("ab", "ba", false)]
    [InlineData("abc", "axcY", false)]
    [InlineData("abc", "aYbcZ", false)]
    [InlineData("abcd", "abXY", false)]
    [InlineData("abc", "axbd", false)]
    [InlineData("aaaa", "aabaa", true)]
    public void IsAtMostOneChange_CoversAllCases(string a, string b, bool expected)
    {
        Assert.Equal(expected, IsAtMostOneChange(a, b));
        Assert.Equal(expected, IsAtMostOneChange(b, a));
    }

    [Fact]
    public void IsAtMostOneChange_NullHandling_IfApplicable()
    {
        Assert.ThrowsAny<System.Exception>(() => IsAtMostOneChange(null!, "a"));
        Assert.ThrowsAny<System.Exception>(() => IsAtMostOneChange("a", null!));
        Assert.ThrowsAny<System.Exception>(() => IsAtMostOneChange(null!, null!));
    }
}