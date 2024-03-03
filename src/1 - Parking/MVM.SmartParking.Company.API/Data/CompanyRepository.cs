using MVM.SmartParking.Company.API.Data.Interfaces;

namespace MVM.SmartParking.Company.API.Data;

public class CompanyRepository : Repository<Models.Company>, ICompanyRepository
{
    public CompanyRepository(DataContext context) : base(context)
    {
    }

    public IUnityOfWork UnityOfWork => _context;
}