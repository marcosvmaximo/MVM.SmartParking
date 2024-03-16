using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class PriceRuleMapping : IEntityTypeConfiguration<PriceRule>
{
    public void Configure(EntityTypeBuilder<PriceRule> builder)
    {
        
    }
}