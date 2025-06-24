using Xunit;

namespace ZyfraClub._25._06;

public sealed class DesignUndergroundSystem 
{
    private const double Tolerance = 0.00001;
    
    public class UndergroundSystem 
    {
        private readonly Dictionary<int, (int time, string stationName)> _checkIns = new();
        private readonly Dictionary<(string from, string to), (long time, long count)> _travelStatistics = new();

        public UndergroundSystem() { }
    
        public void CheckIn(int id, string stationName, int t) 
        {
            _checkIns.Add(id, (t, stationName));
        }
    
        public void CheckOut(int id, string stationName, int t) 
        {
            var (startTime, startStation) = _checkIns[id];
            _checkIns.Remove(id);

            var route = (startStation, stationName);
            if (_travelStatistics.TryGetValue(route, out var statistic))    
                _travelStatistics[route] = (statistic.time + t - startTime, statistic.count + 1);
            else
                _travelStatistics[route] = (t - startTime, 1);
        }
    
        public double GetAverageTime(string startStation, string endStation) 
        {
            var (time, count) = _travelStatistics[(startStation, endStation)];
            return (double)time / count;
        }
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        var sut = new UndergroundSystem();
        
        // Act
        sut.CheckIn(45, "Leyton", 3);
        sut.CheckIn(32,"Paradise",8);
        sut.CheckIn(27,"Leyton",10);
        sut.CheckOut(45,"Waterloo",15);
        sut.CheckOut(27,"Waterloo",20);
        sut.CheckOut(32,"Cambridge",22);
        var timePc = sut.GetAverageTime("Paradise", "Cambridge");
        var timeLw1 = sut.GetAverageTime("Leyton", "Waterloo");
        sut.CheckIn(10,"Leyton",24);
        var timeLw2 = sut.GetAverageTime("Leyton","Waterloo");
        sut.CheckOut(10,"Waterloo",38);
        var timeLw3 = sut.GetAverageTime("Leyton","Waterloo");
        
        // Assert
        Assert.Equal(14.0, timePc, Tolerance);
        Assert.Equal(11.0, timeLw1, Tolerance);
        Assert.Equal(11.0, timeLw2, Tolerance);
        Assert.Equal(12.0, timeLw3, Tolerance);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var sut = new UndergroundSystem();
        
        // Act
        sut.CheckIn(10,"Leyton",3);
        sut.CheckOut(10,"Paradise",8);
        var time1 = sut.GetAverageTime("Leyton","Paradise");
        sut.CheckIn(5,"Leyton",10);
        sut.CheckOut(5,"Paradise",16);
        var time2 = sut.GetAverageTime("Leyton","Paradise");
        sut.CheckIn(2,"Leyton",21);
        sut.CheckOut(2,"Paradise",30);
        var time3 = sut.GetAverageTime("Leyton","Paradise");
        
        // Assert
        Assert.Equal(5.0, time1, Tolerance);
        Assert.Equal(5.5, time2, Tolerance);
        Assert.Equal(6.66667, time3, Tolerance);
    }
}