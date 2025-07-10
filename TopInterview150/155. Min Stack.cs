namespace TopInterview150;

public sealed class MinStackTask 
{
    public sealed class MinStack
    {
        private readonly Stack<int> _stack = new();
        private readonly Stack<int> _minStack = new();

        public void Push(int val)
        {
            var minValue = _minStack.Count > 0 && _minStack.Peek() < val ? _minStack.Peek() : val;
            _stack.Push(val);
            _minStack.Push(minValue);
        }

        public void Pop()
        {
            _ = _stack.Pop();
            _ = _minStack.Pop();
        }

        public int Top() => _stack.Peek();

        public int GetMin() => _minStack.Peek();
    }

    [Fact]
    public void Test()
    {
        // Arrange
        var stack = new MinStack();
        
        // Act
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);
        var min1 = stack.GetMin(); // return -3
        stack.Pop();
        var top = stack.Top();    // return 0
        var min2 = stack.GetMin(); // return -2

        // Assert
        Assert.Equal(-3, min1);
        Assert.Equal(0, top);
        Assert.Equal(-2, min2);
    }
}