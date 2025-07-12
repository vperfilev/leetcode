namespace TopInterview150;

public sealed class CopyListWithRandomPointer
{
    public class Node
    {
        public int val;
        public Node? next;
        public Node? random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class Solution
    {
        public Node? CopyRandomList(Node head)
        {
            if (head is null)
                return head;
            
            var current = head;

            while (current != null)
            {
                var copy = new Node(current.val)
                {
                    next = current.next,
                    random = current.random
                };
                current.next = copy;
                current = copy.next;
            }

            current = head.next;
            var newHead = head.next;
            while (current != null)
            {
                current.random = current.random?.next;
                current = current.next?.next;
            }
            
            current = head;
            while (current != null)
            {
                var nextNode = current.next;
                current.next = current.next?.next;
                current = nextNode;
            }

            return newHead;
        }
    }

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { new int?[][] { new int?[] { 7, null }, new int?[] { 13, 0 }, new int?[] { 11, 4 }, new int?[] { 10, 2 }, new int?[] { 1, 0 } } },
            new object[] { new int?[][] { new int?[] { 1, 1 }, new int?[] { 2, 1 } } },
            new object[] { new int?[][] { new int?[] { 3, null }, new int?[] { 3, 0 }, new int?[] { 3, null } } }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int?[][] input)
    {
        // Arrange
        var solution = new Solution();
        var head = BuildList(input);

        // Act
        var copy = solution.CopyRandomList(head);

        // Assert
        var expected = BuildList(input);
        AssertListsEqual(expected, copy);
    }
    
    private Node? BuildList(int?[][] nodes)
    {
        if (nodes.Length == 0) return null;
        Node?[] nodeArr = new Node[nodes.Length];
        for (int i = 0; i < nodes.Length; i++)
            nodeArr[i] = new Node(nodes[i][0].Value);

        for (int i = 0; i < nodes.Length; i++)
        {
            if (i < nodes.Length - 1)
                nodeArr[i].next = nodeArr[i + 1];
            int? randomIndex = nodes[i][1];
            if (randomIndex.HasValue)
                nodeArr[i].random = nodeArr[randomIndex.Value];
        }
        return nodeArr[0];
    }

    // Вспомогательный метод для проверки эквивалентности списков
    private void AssertListsEqual(Node? expected, Node? actual)
    {
        var expectedNodes = new List<Node?>();
        var actualNodes = new List<Node?>();
        var e = expected;
        var a = actual;
        while (e != null && a != null)
        {
            expectedNodes.Add(e);
            actualNodes.Add(a);
            e = e.next;
            a = a.next;
        }
        Assert.True(e == null && a == null, "Lists have different lengths");

        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i].val, actualNodes[i].val);
            int? expectedRandom = expectedNodes[i].random == null ? (int?)null : expectedNodes.IndexOf(expectedNodes[i].random);
            int? actualRandom = actualNodes[i].random == null ? (int?)null : actualNodes.IndexOf(actualNodes[i].random);
            Assert.Equal(expectedRandom, actualRandom);
        }
    }
}