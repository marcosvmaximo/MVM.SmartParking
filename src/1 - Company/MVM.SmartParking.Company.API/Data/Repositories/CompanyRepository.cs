
using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Company.API.Data.Interfaces;

namespace MVM.SmartParking.Company.API.Data;

public class CompanyRepository : Repository<Models.Company>, ICompanyRepository
{
    public CompanyRepository(DataContext context) : base(context)
    {
    }

    public async Task<Models.Company?> GetByCnpj(string cnpj)
    {
        return await _context.Companies.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
    }

    public IUnityOfWork UnityOfWork => _context;
}