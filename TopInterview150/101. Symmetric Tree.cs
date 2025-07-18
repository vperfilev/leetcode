using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class SymmetricTree
{
    public class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root, root);

            bool IsMirror(TreeNode? q, TreeNode? p)
            {
                return (p == null && q == null)
                       || (p != null && q != null && p.val == q.val
                           && IsMirror(q.left, p.right)
                           && IsMirror(q.right, p.left));
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(TreeNode root, bool expected)
        {
            // Arrange
            var sut = new Solution();

            // Act
            var isSymmetric = sut.IsSymmetric(root);

            // Assert
            Assert.Equal(expected, isSymmetric);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    new int?[] { 1, 2, 2, 3, 4, 4, 3 }.ToTreeNode()!,
                    true
                },
                new object[]
                {
                    new int?[] { 1, 2, 2, null, 3, null, 3 }.ToTreeNode()!,
                    false
                },
                new object[]
                {
                    new int?[] { }.ToTreeNode()!,
                    true
                }
            };
    }
}