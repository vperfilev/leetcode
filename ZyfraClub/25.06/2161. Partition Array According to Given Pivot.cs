using Xunit;

namespace ZyfraClub._25._06;

public sealed class PartitionArrayAccordingToGivenPivot
{
    public class Solution
    {
        public int[] PivotArray(int[] nums, int pivot)
        {
            var endOfFirstSegment = PartitionFrom(0, nums, x => x < pivot);
            _ = PartitionFrom(endOfFirstSegment, nums, x => x == pivot);
            return nums;
        }

        private int PartitionFrom(int start, int[] nums, Func<int, bool> match)
        {
            var (r, l) = (start, start);
            while (r < nums.Length)
            {
                if (match(nums[r]))
                {
                    var temp = nums[r];
                    Array.Copy(nums, l, nums, l + 1, r - l);
                    nums[l++] = temp;
                }

                r++;
            }

            return l;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [9, 12, 5, 10, 14, 3, 10];
        var pivot = 10;

        // Act
        var result = sut.PivotArray(nums, pivot);

        // Assert
        Assert.Equal([9, 5, 3, 10, 10, 12, 14], result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-3, 4, 3, 2];
        var pivot = 2;

        // Act
        var result = sut.PivotArray(nums, pivot);

        // Assert
        Assert.Equal([-3, 2, 4, 3], result);
    }
}