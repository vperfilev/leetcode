using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class RemoveNthNodeFromEndOfList
{
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
        var head = values.ToLinkedList();
        var sut = new Solution();

        // Act
        var result = sut.RemoveNthFromEnd(head!, n);

        // Assert
        Assert.Equal(expected, result.ToArray());
    }
}