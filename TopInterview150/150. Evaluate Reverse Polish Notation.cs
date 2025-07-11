namespace TopInterview150;

public sealed class EvaluateReversePolishNotation
{
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            var operands = new Stack<int>();
            foreach (var token in tokens)
                if (int.TryParse(token, out var operand))
                {
                    operands.Push(operand);
                }
                else
                {
                    var b = operands.Pop();
                    var a = operands.Pop();
                    operands.Push(token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b
                    });
                }

            return operands.Pop();
        }
    }

    [Theory]
    [InlineData(new [] {"2","1","+","3","*"}, 9)]
    [InlineData(new [] {"4","13","5","/","+"}, 6)]
    [InlineData(new [] {"10","6","9","3","+","-11","*","/","*","17","+","5","+"}, 22)]
    public void Test(string[] tokens, int expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var result = sut.EvalRPN(tokens);
        
        // Assert
        Assert.Equal(expected, result);
    }
}