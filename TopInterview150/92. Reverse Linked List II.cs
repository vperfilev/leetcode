using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class ReverseLinkedList2
{
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
        var head = values.ToLinkedList();
        var sut = new Solution();

        // Act
        var reversed = sut.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, reversed.ToArray());
    }
}