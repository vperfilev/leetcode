using Xunit;

namespace ZyfraClub._25._07;

public sealed class IteratorForCombination 
{
    public class CombinationIterator 
    {
        private readonly string _characters;
        private readonly int[] _selectors;
        private bool _hasNext;

        public CombinationIterator(string characters, int combinationLength) 
        {
            _characters = characters;
            _selectors = Enumerable.Range(0, combinationLength).ToArray();
            _hasNext = characters.Length >= combinationLength;
        }
    
        public string Next() 
        {
            if (!_hasNext) throw new InvalidOperationException();
            var next = new string(_selectors.Select(x => _characters[x]).ToArray());
            _hasNext = MoveNext();
            return next;
        }
    
        public bool HasNext() 
        {
            return _hasNext;
        }

        private bool MoveNext()
        {
            var index = _selectors.Length - 1;
            var value = 0;
            var maxChar = _characters.Length;
            
            while(index >= 0)
            {
                value = ++_selectors[index];
                if (value == maxChar--)
                    index--;
                else
                    break;
            }

            if (index < 0) return false;

            for(var i = index + 1; i < _selectors.Length; i++)
                _selectors[i] = ++value;

            return value < _characters.Length;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var iterator = new CombinationIterator("abc", 2);
        var actual = new List<string>(3);
        
        // Act
        do
        {
            actual.Add(iterator.Next());
        } while (iterator.HasNext());
        
        // Assert
        Assert.Equal(["ab", "ac", "bc"], actual);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var iterator = new CombinationIterator("abcd", 3);
        var actual = new List<string>();
        
        // Act
        do
        {
            actual.Add(iterator.Next());
        } while (iterator.HasNext());
        
        // Assert
        Assert.Equal(["abc", "abd", "acd", "bcd"], actual);
    }
}