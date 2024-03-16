using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class ContacMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        throw new NotImplementedException();
    }
}