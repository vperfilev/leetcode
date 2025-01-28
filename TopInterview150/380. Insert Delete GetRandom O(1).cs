namespace TopInterview150;

public class RandomizedSetClass
{
    public class RandomizedSet
    {
        private readonly Dictionary<int, int> _valToIndex = new();
        private readonly List<int> _values = new();
        private readonly Random _random = new();
        
        public bool Insert(int val)
        {
            if (_valToIndex.ContainsKey(val))
                return false;

            _valToIndex[val] = _values.Count;
            _values.Add(val);

            return true;
        }

        public bool Remove(int val)
        {
            if (!_valToIndex.ContainsKey(val))
                return false;

            var removeIndex = _valToIndex[val];
            var lastElement = _values[^1];
            
            _values[removeIndex] = lastElement;
            _values.RemoveAt(_values.Count - 1);
            
            _valToIndex[lastElement] = removeIndex;
            _valToIndex.Remove(val);
            return true;
        }

        public int GetRandom()
        {
            return _values[_random.Next(_values.Count)];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new RandomizedSet();

        // Act
        var insert1 = sut.Insert(1);
        var remove1 = sut.Remove(2);
        var insert2 =sut.Insert(2);
        var random1 = sut.GetRandom();
        var remove2 = sut.Remove(1);
        var insert3 =sut.Insert(2);
        var random2 =sut.GetRandom();
        
        // Assert
        Assert.True(insert1);
        Assert.False(remove1);
        Assert.True(insert2);
        Assert.True(random1 == 1 || random1 == 2);
        Assert.True(remove2);
        Assert.False(insert3);
        Assert.Equal(2, random2);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new RandomizedSet();

        // Act
        var remove1 = sut.Remove(0);
        var remove2 = sut.Remove(0);
        var insert1 =sut.Insert(0);
        var random1 = sut.GetRandom();
        var remove3 = sut.Remove(0);
        var insert2 =sut.Insert(0);
        
        // Assert
        Assert.False(remove1);
        Assert.False(remove2);
        Assert.True(insert1);
        Assert.Equal(0, random1);
        Assert.True(remove3);
        Assert.True(insert2);
    }
}