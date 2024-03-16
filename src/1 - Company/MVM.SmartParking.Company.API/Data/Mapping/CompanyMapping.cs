using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Models.Company>
{
    public void Configure(EntityTypeBuilder<Models.Company> builder)
    {
        throw new NotImplementedException();
    }
}