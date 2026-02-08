namespace TopInterview150;

public sealed class LetterCombinationsOfAPhoneNumber 
{
    public class Solution 
    {
        public IList<string> LetterCombinations(string digits) 
        {
            var combinationsCount = digits.Select(x => DigitToLetter[x].Length)
                .Aggregate(1, (current, combination) => current * combination);

            var result = Enumerable.Range(0, combinationsCount).Select(_ => new char[digits.Length]).ToList();

            var combinationCount = 1;
            for(var i = 0; i < digits.Length; i++)
            {
                var letters = DigitToLetter[digits[i]];
                combinationCount *= letters.Length;
                var repeatInterval = combinationsCount / combinationCount;

                for (var j = 0; j < combinationsCount; j++)
                {
                    var letterIndex = (j / repeatInterval) % letters.Length;
                    result[j][i] = letters[letterIndex];
                }
            }
                
            return result.Select(x => new string(x)).ToList(); 
        }
        
        static readonly Dictionary<char, string> DigitToLetter = new()
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var digits = "23";

        // Act
        var combinations = sut.LetterCombinations(digits);

        // Assert
        var expected = new List<string>
            { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
        Assert.Equal(expected, combinations);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var digits = "2";

        // Act
        var combinations = sut.LetterCombinations(digits);

        // Assert
        var expected = new List<string> {"a","b","c" };
        Assert.Equal(expected, combinations);
    }   
}