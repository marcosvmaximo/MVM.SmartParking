using MVM.SmartParking.Domain.Core;
using MVM.SmartParking.Parking.Domain.Entities.Validations;

namespace MVM.SmartParking.Parking.Domain.Entities;

public class Ticket : Entity
{
    public Ticket(Guid companyId, Guid vehicleId, DateTime entryDate)
    {
        CompanyId = companyId;
        VehicleId = vehicleId;
        EntryDate = entryDate;
        
        Validate();
    }

    public Guid CompanyId { get; private set; }
    public Guid VehicleId { get; private set; }
    public DateTime EntryDate { get; private set; }
    public DateTime? ExitDate { get; private set; }
    public decimal? Amount { get; private set; }
    
    // Ef Relations
    public Company Company { get; private set; }
    public Vehicle Vehicle { get; private set; }

    public sealed override void Validate() => DomainValidations.ValidateTicket(this);

    public void CheckOut(DateTime exitDate)
    {
        ExitDate = exitDate;
        Amount = CalculateAmount();
    }

    private decimal CalculateAmount()
    {
        // Obter diferença de datas
        return 0m;
    }
}