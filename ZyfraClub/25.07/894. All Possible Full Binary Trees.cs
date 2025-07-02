using Xunit;

namespace ZyfraClub._25._07;

public sealed class AllPossibleFullBinaryTrees
{
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

    public class Solution
    {
        private static readonly TreeNode? SingleNode = new();
        private static readonly TreeNode? SimpleNode = new(0, SingleNode, SingleNode);

        public IList<TreeNode> AllPossibleFBT(int n)
        {
            if (n % 2 == 0)
                return new List<TreeNode>();

            var dp = new List<TreeNode?>[n + 1];
            dp[1] = [SingleNode];
            dp[3] = [SimpleNode];

            for (var i = 5; i <= n; i += 2)
            {
                var trees = new List<TreeNode?>();
                for (var j = 1; j < i; j += 2)
                    foreach (var lt in dp[j])
                        foreach (var rt in dp[i - j - 1])
                            trees.Add(new TreeNode(0, lt, rt));
                dp[i] = trees;
            }

            return dp[n].Select(Copy).ToList();

            TreeNode? Copy(TreeNode? node)
            {
                return node is null ? null : new TreeNode(0, Copy(node.left), Copy(node.right));
            }
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var n = 7;

        // Act
        var trees = sut.AllPossibleFBT(n);

        // Assert
        Assert.Equal([
            "0,0,null,null,0,0,null,null,0,0,null,null,0,null,null",
            "0,0,null,null,0,0,0,null,null,0,null,null,0,null,null",
            "0,0,0,null,null,0,null,null,0,0,null,null,0,null,null",
            "0,0,0,null,null,0,0,null,null,0,null,null,0,null,null",
            "0,0,0,0,null,null,0,null,null,0,null,null,0,null,null"]
            , trees.Select(Serialize));
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var n = 3;

        // Act
        var trees = sut.AllPossibleFBT(n);

        // Assert
        Assert.Equal(["0,0,null,null,0,null,null"], trees.Select(Serialize));
    }
    
    private string Serialize(TreeNode? node) 
        => node == null 
            ? "null" : $"0,{Serialize(node.left)},{Serialize(node.right)}";
}