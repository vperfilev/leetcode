namespace TopInterview150;

public class ThreeSum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var sums = new HashSet<(int, int ,int)>();
            Array.Sort(nums);

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[1-1]) continue;

                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        sums.Add((nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                    }

                    if (sum < 0)
                        left++;
                    if (sum > 0)
                        right--;
                }
            }
            return sums.Select(x => new List<int>() { x.Item1, x.Item2, x.Item3 } as IList<int>).ToList();
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [-1,0,1,2,-1,-4];
        
        // Act
        var threeSums = sut.ThreeSum(nums);

        // Assert
        Assert.Equal([[-1,-1,2],[-1,0,1]], threeSums);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,1,1];
        
        // Act
        var threeSums = sut.ThreeSum(nums);

        // Assert
        Assert.Equal([], threeSums);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var sut = new Solution();
        int[] nums = [0,0,0];
        
        // Act
        var threeSums = sut.ThreeSum(nums);

        // Assert
        Assert.Equal([[0,0,0]], threeSums);
    }
}