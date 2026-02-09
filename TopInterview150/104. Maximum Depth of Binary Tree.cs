using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;

namespace TopInterview150;

public sealed class MaximumDepthOfBinaryTree
{
    public class Solution
    {
        public int MaxDepth(TreeNode? root)
        {
            return root == null
                ? 0
                : Math.Max(MaxDepth(root.left) + 1, MaxDepth(root.right) + 1);
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new Solution();
            var values = new int?[] { 3, 9, 20, null, null, 15, 7 };

            // Act
            var maxDepth = sut.MaxDepth(values.ToTreeNode());

            // Assert
            Assert.Equal(3, maxDepth);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var sut = new Solution();
            var values = new int?[] { 1, null, 2 };

            // Act
            var maxDepth = sut.MaxDepth(values.ToTreeNode());

            // Assert
            Assert.Equal(2, maxDepth);
        }
    }
}