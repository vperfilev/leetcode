using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;

namespace TopInterview150;

public sealed class MergeTwoSortedLists
{
    public class Solution
    {
        public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            if (list1 == null || list2 == null)
                return list1 ?? list2;

            var head = SelectMinValue(ref list1, ref list2);
            var prev = head;

            while (list1 != null && list2 != null)
            {
                var nextNode = SelectMinValue(ref list1, ref list2);
                prev!.next = nextNode;
                prev = nextNode;
            }

            prev!.next = list1 ?? list2;

            return head;

            static ListNode? SelectMinValue(ref ListNode? list1, ref ListNode? list2)
            {
                ListNode? result;
                if (list1!.val < list2!.val)
                {
                    result = list1;
                    list1 = list1.next;
                }
                else
                {
                    result = list2;
                    list2 = list2.next;
                }

                return result;
            }
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new int[] { }, new[] { 0 }, new[] { 0 })]
    public void Test(int[] list1, int[] list2, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var l1 = list1.ToLinkedList();
        var l2 = list2.ToLinkedList();
        
        // Act
        var merged = sut.MergeTwoLists(l1, l2);
        
        // Assert
        Assert.Equal(expected, merged.ToArray());
    }
}