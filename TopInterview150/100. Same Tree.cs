using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class SameTree
{
    public class Solution
    {
        public bool IsSameTree(TreeNode? p, TreeNode? q)
        {
            if (p == null || q == null) return p == null && q == null;
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode p, TreeNode q, bool expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var isSameTree = sut.IsSameTree(p, q);
        
        // Assert
        Assert.Equal(expected, isSameTree);
    }
    
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new int?[] { 1, 2, 3 }.ToTreeNode()!,
                new int?[] { 1, 2, 3 }.ToTreeNode()!,
                true
            },
            new object[]
            {
                new int?[] { 1, 2 }.ToTreeNode()!,
                new int?[] { 1, null, 2 }.ToTreeNode()!,
                false
            },
            new object[]
            {
                new int?[] { 1, 2, 1 }.ToTreeNode()!,
                new int?[] { 1, 1, 2 }.ToTreeNode()!,
                false
            }
        };
}