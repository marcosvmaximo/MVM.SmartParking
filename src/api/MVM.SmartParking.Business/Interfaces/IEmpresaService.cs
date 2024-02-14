using MVM.SmartParking.Business.Entities;

namespace MVM.SmartParking.Business.Interfaces;

public interface IEmpresaService
{
    Task CriarEmpresa(Empresa empresa);
    Task CadastrarVeiculo(Veiculo veiculo);
}