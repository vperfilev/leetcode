using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class RemoveDuplicatesFromSortedList2
{
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
    [InlineData(new[] { 1, 2, 3, 3, 4, 4, 5 }, new[] { 1, 2, 5 })]
    [InlineData(new[] { 1, 1, 1, 2, 3 }, new[] { 2, 3 })]
    public void Test(int[] head, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var list = head.ToLinkedList();

        // Act
        var deduplicated = sut.DeleteDuplicates(list);

        // Assert
        Assert.Equal(expected, deduplicated.ToArray());
    }
}