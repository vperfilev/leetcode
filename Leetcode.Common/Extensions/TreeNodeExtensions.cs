using Leetcode.Common.Definitions;

namespace Leetcode.Common.Extensions;

public static class TreeNodeExtensions
{
    public static TreeNode? ToTreeNode(this int?[] values)
    {
        if (values.Length == 0 || values[0] == null)
            return null;

        var root = new TreeNode(values[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (var i = 1; i < values.Length; i++)
        {
            var current = queue.Dequeue();
            if (values[i] != null)
            {
                current.left = new TreeNode(values[i]!.Value);
                queue.Enqueue(current.left);
            }

            if (++i < values.Length && values[i] != null)
            {
                current.right = new TreeNode(values[i]!.Value);
                queue.Enqueue(current.right);
            }
        }

        return root;
    }
    
    public static bool IsBalanced(this TreeNode? node)
    {
        if (node == null) return true;

        var leftHeight = GetHeight(node.left);
        var rightHeight = GetHeight(node.right);

        if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
            return false;

        return true;
    }

    private static int GetHeight(TreeNode? nodeLeft)
    {
        if (nodeLeft == null) return 0;

        var leftHeight = GetHeight(nodeLeft.left);
        var rightHeight = GetHeight(nodeLeft.right);

        if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}