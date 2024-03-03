using MVM.SmartParking.Core;

namespace MVM.SmartParking.Company.API.Data.Interfaces;

public interface ICompanyRepository : IRepository<Models.Company>
{
    IUnityOfWork UnityOfWork { get; }
}