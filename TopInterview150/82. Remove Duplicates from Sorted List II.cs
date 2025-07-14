namespace TopInterview150;

public sealed class RemoveDuplicatesFromSortedList2
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
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head?.next == null) return head;
            var dummy = new ListNode(int.MinValue, head);
            var prev = dummy;
            while (head != null)
                if (head.next?.val == head.val)
                {
                    var dup = head.val;
                    while (head != null && head.val == dup)
                        head = head.next;

                    prev.next = head;
                }
                else
                {
                    prev = head;
                    head = head.next;
                }

            return dummy.next;
        }
    }

    [Theory]
    [InlineData(new[] {1, 2, 3, 3, 4, 4, 5}, new[] {1, 2, 5})]
    [InlineData(new[] {1, 1, 1, 2, 3}, new[] {2, 3})]
    public void Test(int[] head, int[] expected)
    {   
        // Arrange
        var sut = new Solution();
        var list = CreateLinkedList(head);
        
        // Act
        var deduplicated = sut.DeleteDuplicates(list);
        
        // Assert
        Assert.Equal(expected, ToArray(deduplicated));
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