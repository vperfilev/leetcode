namespace TopInterview150;

public class GasStation
{
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var currentTank = 0;
            var totalTank = 0;
            var startStation = 0;
            for (var i = 0; i < gas.Length; i++)
            {
                var difference = gas[i] - cost[i];
                currentTank += difference;
                totalTank += difference;

                if (currentTank >= 0) continue;
                
                currentTank = 0;
                startStation = i + 1;
            }

            return totalTank >= 0 ? startStation : -1;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new Solution();
        int[] gas = [1,2,3,4,5];
        int[] cost = [3,4,5,1,2];
        
        // Act
        var startPoint = sut.CanCompleteCircuit(gas, cost);
        
        // Assert
        Assert.Equal(3, startPoint);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new Solution();
        int[] gas = [2,3,4];
        int[] cost = [3,4,3];
        
        // Act
        var startPoint = sut.CanCompleteCircuit(gas, cost);
        
        // Assert
        Assert.Equal(-1, startPoint);
    }
}