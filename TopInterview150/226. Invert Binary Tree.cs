using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class InvertBinaryTree
{
    public class Solution
    {
        public TreeNode? InvertTree(TreeNode? root)
        {
            if (root == null) return root;
            return new TreeNode(root.val, InvertTree(root.right)!, InvertTree(root.left)!);
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode root, TreeNode expected)
    {
        // Arrange
        var sut = new Solution();

        // Act
        var invertedTree = sut.InvertTree(root);

        // Assert
        Assert.True(new SameTree.Solution().IsSameTree(invertedTree, expected));
    }

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new int?[] { 4, 2, 7, 1, 3, 6, 9 }.ToTreeNode()!,
                new int?[] { 4, 7, 2, 9, 6, 3, 1 }.ToTreeNode()!
            },
            new object[]
            {
                new int?[] { 2, 1, 3 }.ToTreeNode()!,
                new int?[] { 2, 3, 1 }.ToTreeNode()!
            },
            new object[]
            {
                new int?[] { }.ToTreeNode()!,
                new int?[] { }.ToTreeNode()!
            }
        };
}