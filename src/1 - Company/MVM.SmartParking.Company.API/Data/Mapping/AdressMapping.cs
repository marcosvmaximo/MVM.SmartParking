using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class AdressMapping : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
    {
        throw new NotImplementedException();
    }
}