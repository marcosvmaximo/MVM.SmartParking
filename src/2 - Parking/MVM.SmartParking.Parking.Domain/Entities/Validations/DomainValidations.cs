using MVM.SmartParking.Domain.Core;

namespace MVM.SmartParking.Parking.Domain.Entities.Validations;

public static class DomainValidations
{
    public static void ValidateCompany(Company company)
    {
        if (string.IsNullOrWhiteSpace(company.Name))
            throw new DomainException(nameof(company), "Nome da empresa é obrigatório");
        
        // if(company.Name.Length )
    }

    public static void ValidateTicket(Ticket ticket)
    {
        
    }
    
    public static void ValidateVehicle(Vehicle vehicle)
    {
        
    }
}