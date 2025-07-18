using TopInterview150.Definitions;
using TopInterview150.Extensions;

namespace TopInterview150;

public sealed class PartitionList
{
    public class Solution
    {
        public ListNode Partition(ListNode head, int x)
        {
            if (head?.next == null) return head!;

            var lHead = new ListNode();
            var gHead = new ListNode();
            var l = lHead;
            var g = gHead;
            while (head != null)
            {
                var next = head.next;
                if (head.val < x)
                {
                    l.next = head;
                    l = head;
                }
                else
                {
                    g.next = head;
                    g = head;
                }

                head.next = null;
                head = next!;
            }

            if (gHead.next == null || lHead.next == null)
                return gHead.next ?? lHead.next;

            l.next = gHead.next;
            return lHead.next;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 4, 3, 2, 5, 2 }, 3, new[] { 1, 2, 2, 4, 3, 5 })]
    [InlineData(new[] { 2, 1 }, 2, new[] { 1, 2 })]
    public void Test(int[] headValues, int x, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var head = headValues.ToLinkedList();

        // Act
        var partition = sut.Partition(head!, x);

        // Assert
        Assert.Equal(expected, partition.ToArray());
    }
}