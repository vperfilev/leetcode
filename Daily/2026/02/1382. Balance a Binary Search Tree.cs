using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;
using Xunit;

namespace Daily._2026._02;

public sealed class BalanceABinarySearchTree 
{
    public class Solution 
    {
        public TreeNode BalanceBST(TreeNode root) 
        {
            var orderedNodes = new List<TreeNode>();
            InOrder(root, orderedNodes);
            return BuildBalancedBST(orderedNodes, 0, orderedNodes.Count - 1)!;
        }

        private TreeNode? BuildBalancedBST(List<TreeNode> orderedNodes, int s, int e)
        {
            if (e < s) return null;
            var mid = s + (e - s) / 2 ;
            var node = orderedNodes[mid];
            node.left = BuildBalancedBST(orderedNodes, s, mid - 1);
            node.right = BuildBalancedBST(orderedNodes, mid + 1, e);
            return node;
        }

        private void InOrder(TreeNode root, List<TreeNode> orderedNodes)
        {
            if (root is {left: { } left})
                InOrder(left, orderedNodes);
            
            orderedNodes.Add(root);
            
            if (root is {right: { } right})
                InOrder(right, orderedNodes);
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var balanced = sut.BalanceBST(new int?[] { 1,null,2,null,3,null,4,null,null }.ToTreeNode()!);
        
        // Assert
        Assert.True(balanced.IsBalanced());
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var balanced = sut.BalanceBST(new int?[] { 2,1,3 }.ToTreeNode()!);
        
        // Assert
        Assert.True(balanced.IsBalanced());
    }
}