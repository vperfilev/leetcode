using Xunit;
using ZyfraClub.Common;

namespace ZyfraClub._25._08;

public sealed class DeleteNodesFromLinkedListPresentInArray
{
    public class Solution
    {
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            var dummy = new ListNode(0, head);
            var valuesToRemove = new HashSet<int>(nums);
            head = dummy;
            while (head.next != null)
                if (valuesToRemove.Contains(head.next.val))
                    head.next = head.next.next;
                else
                    head = head.next;

            return dummy.next;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, 5 }, new[] { 4, 5 })]
    [InlineData(new[] { 1 }, new[] { 1, 2, 1, 2, 1, 2 }, new[] { 2, 2, 2 })]
    [InlineData(new[] { 5 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
    public void Test(int[] nums, int[] headValues, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var head = ListNode.FromValues(headValues);

        // Act
        var modifiedList = sut.ModifiedList(nums, head);

        // Assert
        Assert.Equal(modifiedList.Values, expected);
    }
}