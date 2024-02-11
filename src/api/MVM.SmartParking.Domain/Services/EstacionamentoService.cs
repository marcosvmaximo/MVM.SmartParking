using MVM.SmartParking.Domain.Entities;
using MVM.SmartParking.Domain.Enum;
using MVM.SmartParking.Domain.Interfaces;

namespace MVM.SmartParking.Domain.Services;

public class EstacionamentoService : IEstacionamentoService
{
    public Task CadastrarVeiculo(ETipoAutomovel tipo, string placa, string cor, int marcaId, int modeloId)
    {
        throw new NotImplementedException();
    }

    public Task MarcarEntrada(Veiculo veiculo)
    {
        throw new NotImplementedException();
    }

    public Task MarcarSaida(Veiculo veiculo)
    {
        throw new NotImplementedException();
    }
}