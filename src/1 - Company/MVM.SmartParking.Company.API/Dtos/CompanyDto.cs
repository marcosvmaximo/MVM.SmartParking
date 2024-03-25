using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Dtos;

public class CompanyDto
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public int NumberCarSpace { get; set; }
    public int NumberMotoSpace { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public AdressDto AdressDto { get; set; }
    public ContactDto ContactDto { get; set; }
    public ICollection<PriceRuleDto> PriceRules { get; set; }
}