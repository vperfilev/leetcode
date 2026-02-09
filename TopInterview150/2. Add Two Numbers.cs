using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;

namespace TopInterview150;

public sealed class AddTwoNumbers
{
    public class Solution
    {
        public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            ListNode? result = null;
            ListNode? prev = null;
            var caryOn = 0;

            while (l1 != null || l2 != null)
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + caryOn;
                caryOn = sum / 10;
                sum -= caryOn * 10;

                l1 = l1?.next;
                l2 = l2?.next;

                var node = new ListNode(sum);
                if (prev != null)
                    prev.next = node;
                prev = node;
                result ??= node;
            }

            if (caryOn > 0)
                prev!.next = new ListNode(caryOn);

            return result;
        }
    }
    
    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void TestAddTwoNumbers(int[] l1, int[] l2, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var list1 = l1.ToLinkedList();
        var list2 = l2.ToLinkedList();

        // Act
        var result = sut.AddTwoNumbers(list1, list2);

        // Assert
        Assert.Equal(expected, result.ToArray());
    }
}
