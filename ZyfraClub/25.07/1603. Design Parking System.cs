using Xunit;

namespace ZyfraClub._25._07;

public sealed class DesignParkingSystem
{
    public sealed class ParkingSystem
    {
        private int _big;
        private int _medium;
        private int _small;

        public ParkingSystem(int big, int medium, int small)
        {
            _big = big;
            _medium = medium;
            _small = small;
        }

        public bool AddCar(int carType)
        {
            ref var count = ref GetCounter(carType);
            return --count >= 0;

            ref int GetCounter(int type)
            {
                switch (type)
                {
                    case 1: return ref _big;
                    case 2: return ref _medium;
                    case 3: return ref _small;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
    
    [Fact]
    public void Test()
    {
        var parking = new ParkingSystem(1, 1, 0);

        Assert.True(parking.AddCar(1));
        Assert.True(parking.AddCar(2));
        Assert.False(parking.AddCar(3));
        Assert.False(parking.AddCar(1));
    }
}