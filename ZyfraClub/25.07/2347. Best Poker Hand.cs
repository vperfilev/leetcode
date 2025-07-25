using Xunit;

namespace ZyfraClub._25._07;

public sealed class BestPokerHand 
{
    public class Solution {
        public string BestHand(int[] ranks, char[] suits) 
        {
            if (suits[0] == suits[1] && suits[0] == suits[2] && suits[0] == suits[3] && suits[0] == suits[4])
                return "Flush";

            Span<int> rankCount = stackalloc int[14];
            foreach(var rank in ranks)
                rankCount[rank]++;

            var maxRank = rankCount[1];
            for(var i = 2; i < rankCount.Length; i++)
                if (maxRank < rankCount[i]) maxRank = rankCount[i];

            return maxRank switch
            {
                >= 3 => "Three of a Kind",
                2 => "Pair",
                _ => "High Card"
            };
        }
    }
    
    /*
Example 1:

Input: 
Explanation: The hand with all the cards consists of 5 cards with the same suit, so we have a "Flush".
Example 2:

Input: ranks = 
Explanation: The hand with the first, second, and fourth card consists of 3 cards with the same rank, so we have a "Three of a Kind".
Note that we could also make a "Pair" hand but "Three of a Kind" is a better hand.
Also note that other cards could be used to make the "Three of a Kind" hand.
Example 3:

Input: 
Explanation: The hand with the first and second card consists of 2 cards with the same rank, so we have a "Pair".
Note that we cannot make a "Flush" or a "Three of a Kind".
     */

    [Theory]
    [InlineData(new []{13,2,3,1,9}, new[]{'a','a','a','a','a'}, "Flush")]
    [InlineData(new []{4,4,2,4,4}, new[]{'d','a','a','b','c'}, "Three of a Kind")]
    [InlineData(new []{10,10,2,12,9}, new[]{'a','b','c','a','d'}, "Pair")]
    [InlineData(new []{3,3,13,7,3}, new[]{'a','d','d','d','c'}, "Three of a Kind")]
    public void Test(int[] ranks, char[] suits, string expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var bestHand = sut.BestHand(ranks, suits);

        // Assert
        Assert.Equal(expected, bestHand);
    }
}