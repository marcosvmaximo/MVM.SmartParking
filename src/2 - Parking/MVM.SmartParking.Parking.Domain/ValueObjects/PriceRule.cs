using MVM.SmartParking.Domain.Core;

namespace MVM.SmartParking.Parking.Domain.ValueObjects;

public class PriceRule : ValueObject
{
    public PriceRule(TimeSpan time, decimal priceForTime)
    {
        Time = time;
        PriceForTime = priceForTime;
        
        // 15min = preço R$10
        // 30min = preço R$15
        // 1h+ = preço R$25
    }

    public TimeSpan Time { get; private set; }
    public decimal PriceForTime { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Time;
        yield return PriceForTime;
    }
}