using MVM.SmartParking.Business.Entities;
using MVM.SmartParking.Core;

namespace MVM.SmartParking.Business.Interfaces;

public interface IEmpresaRepository : IRepository<Empresa>
{
    Task<Empresa?> ObterPorCnpj(string cnpj);
}