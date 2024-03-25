using MVM.SmartParking.Core;
using MVM.SmartParking.Data.Core;

namespace MVM.SmartParking.Company.API.Data.Interfaces;

public interface ICompanyRepository : IRepository<Models.Company>
{
    Task<Models.Company?> GetByCnpj(string cnpj);
    IUnityOfWork UnityOfWork { get; }
}