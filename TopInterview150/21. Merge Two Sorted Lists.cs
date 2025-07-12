namespace TopInterview150;

public sealed class MergeTwoSortedLists
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

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
        var l1 = CreateLinkedList(list1);
        var l2 = CreateLinkedList(list2);
        
        // Act
        var merged = sut.MergeTwoLists(l1, l2);
        
        // Assert
        Assert.Equal(expected, ToArray(merged));
    }

    private int[] ToArray(ListNode? listNode)
    {
        var result = new List<int>();
        while (listNode != null)
        {
            result.Add(listNode.val);
            listNode = listNode.next;
        }
        return result.ToArray();
    }

    private ListNode? CreateLinkedList(int[] list1)
    {
        if (list1.Length == 0)
            return null;

        var head = new ListNode(list1[0]);
        var current = head;

        for (var i = 1; i < list1.Length; i++)
        {
            current.next = new ListNode(list1[i]);
            current = current.next;
        }

        return head;
    }
}