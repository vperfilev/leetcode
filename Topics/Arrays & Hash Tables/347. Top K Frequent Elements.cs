using Xunit;

namespace Topics.Arrays___Hash_Tables;

public sealed class TopKFrequentElements 
{
    public class Solution 
    {
        public int[] TopKFrequent(int[] nums, int k) 
        {
            var counts = new int[20001];
            foreach(var num in nums)
                counts[num + 10000]++;

            var heap = new PriorityQueue<int, int>();
            for(var num = -10000; num <= 10000; num++)
            {
                var count = counts[num + 10000];
                if (count != 0)
                {
                    heap.Enqueue(num, count);
                    if (heap.Count > k)
                        _ =heap.Dequeue();
                } 
            }
        
            return heap.UnorderedItems.Select(item => item.Element).ToArray();
        }
    }
    
    [Theory]
    [InlineData(new[]{1,1,1,2,2,3}, 2, new[]{1,2})]
    [InlineData(new[]{1}, 1, new[]{1})]
    [InlineData(new[]{1,2,1,2,1,2,3,1,3,2}, 2, new[]{1,2})]
    public void Test(int[] nums, int k, int[] expected)
    {
        // Arrange
        var sut = new Solution();
        
        // Act
        var topKFrequent = sut.TopKFrequent(nums, k);
        Array.Sort(topKFrequent);
        
        // Assert
        Assert.Equal(expected, topKFrequent);
    }
}