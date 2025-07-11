namespace TopInterview150;

public sealed class BasicCalculator 
{
    public class Solution {
        public int Calculate(string s) 
        {
            var i = -1;
            var signStack = new Stack<int>();
            signStack.Push(1);
            int result = 0, currentSign = 1;

            while(i < s.Length - 1)
            {
                var c = s[++i];
                
                if (c == '(') 
                    signStack.Push(currentSign);
                else if (c == ')')
                    currentSign = signStack.Pop();
                else if (c == '-')
                    currentSign = -signStack.Peek();
                else if (c == '+')
                    currentSign = signStack.Peek();
                if (!char.IsDigit(c)) continue;
                
                var from = i;
                while (i < s.Length && char.IsDigit(s[i])) i++;
                result += int.Parse(s[from .. i]) * currentSign;
                i--;
            }    
            return result;
        }
    }

    [Theory]
    [InlineData("1 + 1", 2)]
    [InlineData(" 2-1 + 2 ", 3)]
    [InlineData("(1+(4+5+2)-3)+(6+8)", 23)]
    public void Test(string s, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var result = sut.Calculate(s);
        
        // Assert
        Assert.Equal(expected, result);
    }
}