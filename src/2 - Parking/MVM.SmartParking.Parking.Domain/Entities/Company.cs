using MVM.SmartParking.Domain.Core;
using MVM.SmartParking.Parking.Domain.Entities.Validations;
using MVM.SmartParking.Parking.Domain.ValueObjects;

namespace MVM.SmartParking.Parking.Domain.Entities;

public class Company : Entity
{
   private List<Ticket> _tickets;
   private List<PriceRule> _priceRules;

   public Company(string name, string cnpj, int numberCarSpace, int numberMotoSpace)
   {
      Name = name;
      Cnpj = cnpj;
      NumberCarSpace = numberCarSpace;
      NumberMotoSpace = numberMotoSpace;
      
      _priceRules = new();
      _tickets = new();
      
      Validate();
   }
   
   public string Name { get; private set; }
   public string Cnpj { get; private set; }
   public int NumberCarSpace { get; private set; }
   public int NumberMotoSpace { get; private set; }
   public IReadOnlyCollection<PriceRule> PriceRules => _priceRules;
   public IReadOnlyCollection<Ticket> Tickets => _tickets;

   public void AddTicket(Ticket ticket)
   {
      _tickets.Add(ticket);
   }

   public void AddPriceRule(PriceRule rule)
   {
      
   }

   public sealed override void Validate() => DomainValidations.ValidateCompany(this);
}