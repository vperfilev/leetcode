using System.Text.RegularExpressions;

namespace TopInterview150;

public class ValidPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var normalizedString = Regex.Replace(s, @"[^a-zA-Z0-9]", "").ToLower();
            if (normalizedString.Length < 2)
                return true;

            var left = -1;
            var right = normalizedString.Length;

            while (++left < --right)
            {
                if (normalizedString[left] != normalizedString[right])
                    return false;
            }

            return true;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var s = "A man, a plan, a canal: Panama";
        
        // Act
        var isPalindrome = sut.IsPalindrome(s);
        
        // Assert
        Assert.True(isPalindrome);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var s = "race a car";
        
        // Act
        var isPalindrome = sut.IsPalindrome(s);
        
        // Assert
        Assert.False(isPalindrome);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var s = " ";
        
        // Act
        var isPalindrome = sut.IsPalindrome(s);
        
        // Assert
        Assert.True(isPalindrome);
    }
}