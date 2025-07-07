using Xunit;

namespace ZyfraClub._25._07;

public sealed class CircularSentence 
{
    public class Solution {
        public bool IsCircularSentence(string sentence) 
        {
            if (sentence[0] != sentence[^1])
                return false;

            for(var i = 1; i < sentence.Length - 1; i++)
                if (sentence[i] == ' ' && sentence[i - 1] != sentence[i + 1])
                    return false;
            
            return true;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        var sentence = "leetcode exercises sound delightful";
        
        // Act
        var isCircularSentence = sut.IsCircularSentence(sentence);
        
        // Assert
        Assert.True(isCircularSentence);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        var sentence = "eetcode";
        
        // Act
        var isCircularSentence = sut.IsCircularSentence(sentence);
        
        // Assert
        Assert.True(isCircularSentence);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        var sentence = "Leetcode is cool";
        
        // Act
        var isCircularSentence = sut.IsCircularSentence(sentence);
        
        // Assert
        Assert.False(isCircularSentence);
    }
}