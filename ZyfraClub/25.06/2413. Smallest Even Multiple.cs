using Xunit;

namespace ZyfraClub._25._06;

public sealed class SmallestEvenMultiple 
{
    public class Solution 
    {
        public int SmallestEvenMultiple(int n) => n % 2 == 0 ? n : n << 1;
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var result = sut.SmallestEvenMultiple(5);
        
        // Assert
        Assert.Equal(10, result);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var result = sut.SmallestEvenMultiple(6);
        
        // Assert
        Assert.Equal(6, result);
    }
}