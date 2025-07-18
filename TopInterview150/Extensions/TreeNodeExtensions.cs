using TopInterview150.Definitions;

namespace TopInterview150.Extensions;

internal static class TreeNodeExtensions
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
}