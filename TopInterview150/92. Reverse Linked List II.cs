namespace TopInterview150;

public sealed class ReverseLinkedList2
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
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;

            var dummy = new ListNode(0, head);
            var prev = dummy;
            for (var i = 1; i < left; i++)
                prev = prev.next;

            var current = prev.next;
            for (var i = left; i < right; i++)
            {
                var temp = current.next;
                current.next = temp.next;
                temp.next = prev.next;
                prev.next = temp;
            }

            return dummy.next;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 2, 5 })]
    [InlineData(new[] { 5 }, 1, 1, new[] { 5 })]
    public void Test(int[] values, int left, int right, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(values);
        var sut = new Solution();

        // Act
        var reversed = sut.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, ToArray(reversed));
    }

    private int[] ToArray(ListNode reversed)
    {
        var result = new List<int>();
        while (reversed != null)
        {
            result.Add(reversed.val);
            reversed = reversed.next;
        }
        return result.ToArray();
    }

    private ListNode CreateLinkedList(int[] values)
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
}