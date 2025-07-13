namespace TopInterview150;

public sealed class RemoveNthNodeFromEndOfList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var p = dummy;
            for (var i = 0; i < n; i++)
                p = p.next;

            var element = dummy;
            while (p.next != null)
            {
                p = p.next;
                element = element.next;
            }

            element.next = element.next.next;
            return dummy.next;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3, 5 })]
    [InlineData(new[] { 1 }, 1, new int[] { })]
    [InlineData(new[] { 1, 2 }, 1, new[] { 1 })]
    public void Test(int[] values, int n, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(values);
        var sut = new Solution();

        // Act
        var result = sut.RemoveNthFromEnd(head, n);

        // Assert
        Assert.Equal(expected, ToArray(result));
    }
    
    private static ListNode CreateLinkedList(int[] values)
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
    
    private static int[] ToArray(ListNode head)
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