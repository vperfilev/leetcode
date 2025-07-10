using System.Text.RegularExpressions;

namespace TopInterview150;

public sealed class SimplifyPath
{
    public class Solution
    {
        public string SimplifyPath(string path)
        {
            var segments = new List<string>();

            foreach (var segment in Regex.Split(path, "/+").Where(s => !string.IsNullOrEmpty(s)))
                switch (segment)
                {
                    case "..":
                    {
                        if (segments.Count > 0)
                            segments.RemoveAt(segments.Count - 1);
                        break;
                    }
                    case ".":
                        break;
                    default:
                        segments.Add(segment);
                        break;
                }

            return $"/{string.Join('/', segments)}";
        }
    }

    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/home//foo/", "/home/foo")]
    [InlineData("/home/user/Documents/../Pictures", "/home/user/Pictures")]
    [InlineData("/../", "/")]
    [InlineData("/.../a/../b/c/../d/./", "/.../b/d")]
    public void Test(string path, string expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var simplifiedPath = sut.SimplifyPath(path);
        
        // Assert
        Assert.Equal(expected, simplifiedPath);
    }
}