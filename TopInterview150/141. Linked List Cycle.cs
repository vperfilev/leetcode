using TopInterview150.Definitions;

namespace TopInterview150;

public sealed class LinkedListCycle
{
    public class Solution
    {
        public bool HasCycle(ListNode? head)
        {
            var current = head;

            var dict = new HashSet<ListNode>();
            while (current is not null)
            {
                if (dict.Contains(current))
                    return true;

                dict.Add(current);
                current = current.next;
            }

            return false;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var head = CreateLinkedList([3, 2, 0, -4], 1);

        // Act
        var hasCycle = sut.HasCycle(head);

        // Assert
        Assert.True(hasCycle);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var head = CreateLinkedList([1, 2], 0);

        // Act
        var hasCycle = sut.HasCycle(head);

        // Assert
        Assert.True(hasCycle);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var head = CreateLinkedList([1], -1);

        // Act
        var hasCycle = sut.HasCycle(head);

        // Assert
        Assert.False(hasCycle);
    }

    private ListNode? CreateLinkedList(int[] ints, int pos)
    {
        var nodes = ints.Select(x => new ListNode(x)).ToArray();
        for (var i = 0; i < ints.Length - 1; i++)
            nodes[i].next = nodes[i + 1];

        if (pos >= 0)
            nodes[^1].next = nodes[pos];

        return nodes.FirstOrDefault();
    }
}