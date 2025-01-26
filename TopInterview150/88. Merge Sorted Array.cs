namespace TopInterview150;

public class MergeSortedArray
{
    private class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = m - 1;
            var j = n - 1;
            var k = m + n - 1;

            while (i >= 0 && j >= 0) nums1[k--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];

            while (j >= 0) nums1[k--] = nums2[j--];
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums1 = [1, 2, 3, 0, 0, 0];
        var m = 3;
        int[] nums2 = [2, 5, 6];
        var n = 3;
        int[] expected = [1, 2, 2, 3, 5, 6];

        // Act
        sut.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums1 = [1];
        var m = 1;
        int[] nums2 = [];
        var n = 0;
        int[] expected = [1];

        // Act
        sut.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums1 = [0];
        var m = 0;
        int[] nums2 = [1];
        var n = 1;
        int[] expected = [1];

        // Act
        sut.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }
}