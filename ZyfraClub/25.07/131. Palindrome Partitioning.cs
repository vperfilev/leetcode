using Xunit;

namespace ZyfraClub._25._07;

public sealed class PalindromePartitioning
{
    public class Solution
    {
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            BackTrack(s, result, new Stack<string>(), 0);
            return result;
        }

        private void BackTrack(string s, List<IList<string>> result, Stack<string> chain, int start)
        {
            if (start == s.Length)
            {
                result.Add(chain.Reverse().ToList());
                return;
            }

            for (var j = start; j < s.Length; j++)
                if (IsPalindrome(s, start, j))
                {
                    chain.Push(s[start .. (j + 1)]);
                    BackTrack(s, result, chain, j + 1);
                    _ = chain.Pop();
                }
        }

        private bool IsPalindrome(string s, int f, int t)
        {
            while (f <= t)
                if (s[f++] != s[t--])
                    return false;

            return true;
        }
    }

    public static IEnumerable<object[]> PartitionCases =>
        new List<object[]>
        {
            new object[]
            {
                "aab",
                new List<List<string>>
                {
                    new() { "a", "a", "b" },
                    new() { "aa", "b" }
                }
            },
            new object[]
            {
                "a",
                new List<List<string>>
                {
                    new() { "a" }
                }
            }
        };

    [Theory]
    [MemberData(nameof(PartitionCases))]
    public void Partition_ReturnsAllPalindromePartitions(string s, List<List<string>> expected)
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.Partition(s);

        // Assert 
        Assert.Equal(
            expected.OrderBy(p => string.Join(",", p)),
            result.Select(p => p.ToList()).OrderBy(p => string.Join(",", p)),
            new ListComparer<string>()
        );
    }

    private sealed class ListComparer<T> : IEqualityComparer<IList<T>>
    {
        public bool Equals(IList<T> x, IList<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IList<T> obj)
        {
            return obj.Aggregate(0, (h, v) => h ^ v.GetHashCode());
        }
    }
}