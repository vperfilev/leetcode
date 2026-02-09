using Leetcode.Common.Definitions;

namespace Leetcode.Common.Extensions;

public static class NodeExtensions
{
    public static ListNode? ToLinkedList(this int[] values)
    {
        if (values.Length == 0) return null;

        var head = new ListNode(values[0]);
        var current = head;
        for (var i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return head;
    }
    
    public static int[] ToArray(this ListNode? head)
    {
        var result = new List<int>();
        while (head != null)
        {
            result.Add(head.val);
            head = head.next;
        }
        return result.ToArray();
    }
}