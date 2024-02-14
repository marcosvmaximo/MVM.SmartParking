using MVM.SmartParking.Core;
using MVM.SmartParking.Business.Entities;

namespace MVM.SmartParking.Business;

public class Bilhete : Entity
{
    public Guid EmpresaId { get; set; }
    public Guid VeiculoId { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
    public decimal? ValorTotal { get; set; }
}