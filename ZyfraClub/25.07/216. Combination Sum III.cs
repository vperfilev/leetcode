using Xunit;

namespace ZyfraClub._25._07;

public sealed class CombinationSum3 
{
    public class Solution 
    {
        public IList<IList<int>> CombinationSum3(int k, int n) 
        {
            var result = new List<IList<int>>();
            BackTrack(k, n, new List<int>(), 1, result);
            return result;
        }

        private void BackTrack(int k, int target, List<int> combination, int start, IList<IList<int>> result)
        {
            if (combination.Count == k && target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }

            if (combination.Count > k || target < 0)
                return;

            for (var i = start; i < 10; i++)
            {
                combination.Add(i);
                BackTrack(k, target - i, combination, i + 1, result);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int k, int n, int[][] expected)
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.CombinationSum3(k, n);

        // Assert
        Assert.Equal(
            expected.Length,
            result.Count
        );

        var expectedSets = new HashSet<string>();
        foreach (var arr in expected)
            expectedSets.Add(string.Join(",", arr));

        foreach (var actual in result)
            Assert.Contains(string.Join(",", actual), expectedSets);
    }
    
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { 3, 7, new[] { new[] { 1, 2, 4 } } },
            new object[] { 3, 9, new[] { new[] { 1, 2, 6 }, new[] { 1, 3, 5 }, new[] { 2, 3, 4 } } },
            new object[] { 4, 1, Array.Empty<int[]>() }
        };
}