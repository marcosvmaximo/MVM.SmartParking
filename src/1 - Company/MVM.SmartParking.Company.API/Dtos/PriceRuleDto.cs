namespace MVM.SmartParking.Company.API.Dtos;

public class PriceRuleDto
{
    public TimeSpan Time { get; set; }
    public decimal PriceForTime { get; set; }
}