using System.Text;
using Xunit;

namespace ZyfraClub._25._07;

public sealed class GoalParserInterpretation
{
    public class Solution
    {
        public string Interpret(string command)
        {
            var result = new StringBuilder();
            var l = 0;
            var r = 0;
            while (++r <= command.Length)
                if (TryParse(command[l .. r], out var parsed))
                {
                    result.Append(parsed);
                    l = r;
                }

            return result.ToString();
        }

        private bool TryParse(string element, out string? parsed)
        {
            parsed = element switch
            {
                "G" => "G",
                "()" => "o",
                "(al)" => "al",
                _ => null
            };
            return parsed != null;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var command = "G()(al)";

        // Act
        var result = sut.Interpret(command);

        // Assert
        Assert.Equal("Goal", result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var command = "G()()()()(al)";

        // Act
        var result = sut.Interpret(command);

        // Assert
        Assert.Equal("Gooooal", result);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var command = "(al)G(al)()()G";

        // Act
        var result = sut.Interpret(command);

        // Assert
        Assert.Equal("alGalooG", result);
    }
}