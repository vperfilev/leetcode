using Leetcode.Common.Definitions;
using Leetcode.Common.Extensions;

namespace TopInterview150;

public sealed class RotateList 
{
     public class Solution 
    {
        public ListNode RotateRight(ListNode head, int k) 
        {
            if(head?.next == null || k == 0) return head;

            var p1 = head;
            int i;
            for(i = 0; i < k; i++)
            {
                p1 = p1.next;
                if (p1 == null)
                    break;
            }

            if (i < k)
            {
                k %= i + 1;
                p1 = head;
                for(i = 0; i < k; i++)
                    p1 = p1!.next;
            }

            var p2 = head;
            while(p1!.next != null)
            {
                p1 = p1.next;
                p2 = p2.next ?? head;
            }

        
            p1.next = head;
            head = p2.next!;
            p2.next = null;

            return head;
        }
    }

    [Theory]
    [InlineData(new[]{1,2,3,4,5}, 2, new[]{4,5,1,2,3})]
    [InlineData(new[]{0,1,2}, 4, new[]{2,0,1})]
    [InlineData(new[]{1,2}, 1, new[]{2,1})]
    public void Test(int[] nodes, int k, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        var head = nodes.ToLinkedList();
        
        // Act
        var rotated = sut.RotateRight(head!, k);
        
        // Assert
        Assert.Equal(expected, rotated.ToArray());
    }
}