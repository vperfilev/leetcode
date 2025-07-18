namespace TopInterview150;

public sealed class LruCache
{
    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, ListNode> _cache;
        private ListNode _head;
        private ListNode _tail;

        public LRUCache(int capacity)
        {
            _head = new ListNode();
            _tail = new ListNode();
            _head.next = _tail;
            _tail.prev = _head;
            _cache = new Dictionary<int, ListNode>(capacity);
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node)) return -1;

            Remove(node);
            PutInFront(node);
            return node.val;
        }

        public void Put(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                node.val = value;
                Remove(node);
                PutInFront(node);
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    var toRemove = _tail.prev;
                    Remove(toRemove);
                    _cache.Remove(toRemove.key);
                }

                var newNode = new ListNode { val = value, key = key };
                PutInFront(newNode);
                _cache[key] = newNode;
            }
        }

        private void PutInFront(ListNode node)
        {
            var next = _head.next;
            next.prev = node;
            _head.next = node;
            node.prev = _head;
            node.next = next;
        }

        private void Remove(ListNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private class ListNode
        {
            public int val;
            public int key;
            public ListNode next;
            public ListNode prev;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var cache = new LRUCache(1);

        // Act
        cache.Put(2, 1); // cache is {1=1}
        var get1 = cache.Get(2); // return 1

        // Assert
        Assert.Equal(1, get1);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var cache = new LRUCache(2);

        // Act
        cache.Put(1, 1); // cache is {1=1}
        cache.Put(2, 2); // cache is {1=1, 2=2}
        var get1 = cache.Get(1); // return 1
        cache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        var get2 = cache.Get(2); // returns -1 (not found)
        cache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        var get3 = cache.Get(1); // return -1 (not found)
        var get4 = cache.Get(3); // return 3
        var get5 = cache.Get(4); // return 4

        // Assert
        Assert.Equal(1, get1);
        Assert.Equal(-1, get2);
        Assert.Equal(-1, get3);
        Assert.Equal(3, get4);
        Assert.Equal(4, get5);
    }
}