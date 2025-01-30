using System.Text;
using System.Xml;

namespace TopInterview150;

public class TextJustification
{
    public class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var lines =new List<string>();

            var currentLength = 0;
            var currentLine = new List<string>();
            
            foreach (var word in words)
            {
                if (currentLength + word.Length + currentLine.Count > maxWidth)
                {
                    lines.Add(JustifyLine(currentLine, maxWidth));
                    currentLine.Clear();
                    currentLength = 0;
                }

                currentLine.Add(word);
                currentLength += word.Length;
            }
            
            if (currentLine.Any())
                lines.Add(string.Join(' ', currentLine).PadRight(maxWidth));

            return lines;
        }

        private string JustifyLine(List<string> currentLine, int maxWidth)
        {
            if (currentLine.Count == 1)
                return currentLine[0].PadRight(maxWidth);
            
            var spaceTotal = maxWidth - currentLine.Sum(x => x.Length);
            var space = new string(' ',spaceTotal / (currentLine.Count - 1));
            var extraSpaceCount = spaceTotal % (currentLine.Count - 1);

            var line = new StringBuilder();
            line.Append(currentLine[0]);

            for (var i = 1; i < currentLine.Count; i++)
            {
                line.Append(space);
                if (extraSpaceCount-- > 0)
                    line.Append(' ');
                line.Append(currentLine[i]);
            }

            return line.ToString();
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        string[] worlds = ["This", "is", "an", "example", "of", "text", "justification."];
        var maxWidth = 16;
        
        // Act
        var justificated = sut.FullJustify(worlds, maxWidth);
        
        // Assert
        Assert.Equal([
            "This    is    an",
            "example  of text",
            "justification.  "], justificated);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        string[] worlds = ["What", "must", "be", "acknowledgment", "shall", "be"];
        var maxWidth = 16;

        // Act
        var justificated = sut.FullJustify(worlds, maxWidth);

        // Assert
        Assert.Equal([
            "What   must   be",
            "acknowledgment  ",
            "shall be        "
        ], justificated);
    }
    

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        string[] worlds = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"];
        var maxWidth = 20;
        
        // Act
        var justificated = sut.FullJustify(worlds, maxWidth);
        
        // Assert
        Assert.Equal([
            "Science  is  what we",
            "understand      well",
            "enough to explain to",
            "a  computer.  Art is",
            "everything  else  we",
            "do                  "], justificated);
    }
}
