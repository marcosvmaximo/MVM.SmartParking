using MVM.SmartParking.Core;
using MVM.SmartParking.Domain.Entities;

namespace MVM.SmartParking.Domain;

public class Bilhete : Entity
{
    public Bilhete(Empresa empresa, Veiculo veiculo)
    {
        Empresa = empresa;
        Veiculo = veiculo;

        EmpresaId = empresa.Id;
        VeiculoId = veiculo.Id;
    }

    public Empresa Empresa { get; set; }
    public Guid EmpresaId { get; set; }
    public Veiculo Veiculo { get; set; }
    public Guid VeiculoId { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
    public decimal? ValorTotal { get; set; }

    public void MarcarEntrada(DateTime dataEntrada)
    {
        
    }

    public void MarcarSaida(DateTime dataSaida)
    {
        
    }
}