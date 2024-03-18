using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Models.Company>
{
    public void Configure(EntityTypeBuilder<Models.Company> builder)
    {
        builder.ToTable("Empresas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)");
        
        builder.Property(x => x.Cnpj)
            .HasColumnName("cnpj")
            .HasColumnType("varchar(14)");
        
        builder.Property(x => x.Name)
            .HasColumnName("nome")
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.NumberCarSpace)
            .HasColumnName("quantidade_vagas_carro")
            .HasColumnType("int");
        
        builder.Property(x => x.NumberMotoSpace)
            .HasColumnName("quantidade_vagas_moto")
            .HasColumnType("int");
        
        builder.Property(x => x.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnType("varchar(128)");
        
        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("tinyint");

        builder.HasMany(x => x.Adresses)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
        
        builder.HasMany(x => x.Contacts)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
        
        builder.HasMany(x => x.PriceRules)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId);
    }
}