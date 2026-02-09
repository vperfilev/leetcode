using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;
using Xunit;

namespace Daily._2026._02;

public sealed class BalancedBinaryTree
{
    public class Solution
    {
        public bool IsBalanced(TreeNode root)
        {
            return HeightOrNull(root) != null;
        }

        private int? HeightOrNull(TreeNode? root)
        {
            if (root == null) return 0;

            var leftHeight = HeightOrNull(root.left);
            if (leftHeight == null) return null;

            var rightHeight = HeightOrNull(root.right);
            if (rightHeight == null) return null;

            if (Math.Abs(leftHeight.Value - rightHeight.Value) > 1)
                return null;

            return Math.Max(leftHeight.Value, rightHeight.Value) + 1;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();

        // Act
        var isBalanced = sut.IsBalanced(null!);

        // Assert
        Assert.True(isBalanced);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();

        // Act
        var isBalanced = sut.IsBalanced(new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }.ToTreeNode()!);

        // Assert
        Assert.False(isBalanced);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();

        // Act
        var isBalanced = sut.IsBalanced(new int?[] { 3, 9, 20, null, null, 15, 7 }.ToTreeNode()!);

        // Assert
        Assert.True(isBalanced);
    }

    [Fact]
    public void Test5()
    {
        // Arrange
        var sut = new Solution();

        // Act
        var isBalanced = sut.IsBalanced(new int?[] { 1, 2, 3, 4, 5, 6, null, 8 }.ToTreeNode()!);

        // Assert
        Assert.True(isBalanced);
    }
}