using MVM.SmartParking.Company.API.Models.Base;
using MVM.SmartParking.Domain.Core;

namespace MVM.SmartParking.Company.API.Models;

public class PriceRule : BaseModel
{
    public PriceRule(TimeSpan time, decimal priceForTime)
    {
        Time = time;
        PriceForTime = priceForTime;
    }
    
    public PriceRule(){}

    public TimeSpan Time { get; set; }
    public decimal PriceForTime { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}