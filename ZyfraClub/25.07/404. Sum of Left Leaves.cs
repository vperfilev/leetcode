using Xunit;

namespace ZyfraClub._25._07;

public sealed class SumOfLeftLeaves 
{
    public class Solution 
    {
        public int SumOfLeftLeaves(TreeNode root) 
        {
            var nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            
            var leftSum = 0;
            
            while(nodes.TryDequeue(out var node))
            {
                Enqueue(node.left);
                Enqueue(node.right);
            
                if (IsLeaf(node.left))
                    leftSum += node.left!.val;
            }
            return leftSum;

            void Enqueue(TreeNode? node){
                if (node != null && !IsLeaf(node))
                    nodes.Enqueue(node);
            };
            bool IsLeaf(TreeNode? node) => node is { left: null, right: null };
        }

        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;

            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var sut = new Solution();
            var root = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            
            // Act
            var sum = sut.SumOfLeftLeaves(root);
            
            // Assert
            Assert.Equal(24, sum);
        }
        
        [Fact]
        public void Test2()
        {
            // Arrange
            var sut = new Solution();
            var root = new TreeNode(1);
            
            // Act
            var sum = sut.SumOfLeftLeaves(root);
            
            // Assert
            Assert.Equal(0, sum);
        }
    }    
}