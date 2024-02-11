using MVM.SmartParking.Domain.Entities;
using MVM.SmartParking.Domain.Enum;

namespace MVM.SmartParking.Domain.Interfaces;

public interface IEstacionamentoService
{
    Task CriarEmpresa(Empresa empresa);
    Task CadastrarVeiculo(Veiculo veiculo);
    Task MarcarEntrada(Bilhete bilheteEstacionamento);
    Task MarcarSaida(Bilhete bilheteEstacionamento);
}