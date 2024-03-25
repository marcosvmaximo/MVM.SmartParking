using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class PriceRuleMapping : IEntityTypeConfiguration<PriceRule>
{
    public void Configure(EntityTypeBuilder<PriceRule> builder)
    {
        builder.ToTable("Regras_Tempo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)");
        
        builder.Property(x => x.Time)
            .HasColumnName("tempo")
            .HasColumnType("time");
        
        builder.Property(x => x.PriceForTime)
            .HasColumnName("preco_por_tempo")
            .HasColumnType("decimal(8, 2)");

        builder.HasOne(x => x.Company)
            .WithMany(x => x.PriceRules)
            .HasForeignKey(x => x.CompanyId);
    }
}