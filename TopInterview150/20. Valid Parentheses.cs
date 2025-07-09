namespace TopInterview150;

public sealed class ValidParentheses 
{
    public class Solution 
    {
        private readonly Dictionary<char, char> _symbolPairs = new()
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };

        public bool IsValid(string s) 
        {
            var symbolStack = new Stack<char>();

            foreach(var symbol in s)
            {
                if(_symbolPairs.TryGetValue(symbol, out var openSymbol))
                {
                    if (symbolStack.Count == 0 || symbolStack.Peek() != openSymbol)
                        return false;

                    _ = symbolStack.Pop();
                }
                else
                {
                    symbolStack.Push(symbol);
                }
            }

            return symbolStack.Count == 0;
        }
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([])", true)]
    public void Test(string s, bool expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var isValid = sut.IsValid(s);
        
        // Assert
        Assert.Equal(expected, isValid);
    }
}