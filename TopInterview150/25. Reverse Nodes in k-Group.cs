using Leetcode.Common.Definitions;

namespace TopInterview150;

public sealed class ReverseNodesInKGroup
{
     public class Solution 
     {
         public ListNode? ReverseKGroup(ListNode? head, int k) 
         {
             if (k == 0 || k == 1) return head;

             var resultHead = head;
             ListNode? resultTail = null;

             while (head != null)
             {
                 if (TryReverseKGroup(head, k, out var nextSegment, out var segmentHead, out var segmentTail))
                 {
                     if (resultTail == null)
                         resultHead = segmentHead;
                     else
                         resultTail.next = segmentHead;
                     
                     resultTail = segmentTail;
                     head = nextSegment;
                 }
                 else if (resultTail != null)
                 {
                     resultTail.next = head;
                     break;
                 }
             }

             return resultHead;
         }

         bool TryReverseKGroup(ListNode from, int k, out ListNode? current, out ListNode? head, out ListNode? tail)
         {
             current = from.next;
             tail = new ListNode(from.val);
             head = tail;
             while(--k > 0 && current != null)
             {
                 head = new ListNode(current.val, head);
                 current = current.next;
             }
             return k <= 0 || current != null;
         }
     }

     [Fact]
     public void Test1()
     {
         // Arrange
         var sut = new Solution();
         var k = 2;
         var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
         
         // Act
         var reversed = sut.ReverseKGroup(head, k);
         
         // Assert
         Assert.Equal("2,1,4,3,5", reversed.ToString());
     }
     
     [Fact]
     public void Test2()
     {
         // Arrange
         var sut = new Solution();
         var k = 3;
         var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
         
         // Act
         var reversed = sut.ReverseKGroup(head, k);
         
         // Assert
         Assert.Equal("3,2,1,4,5", reversed.ToString());
     }
}