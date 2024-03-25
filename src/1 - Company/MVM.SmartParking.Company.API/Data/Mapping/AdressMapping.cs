using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class AdressMapping : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)");
        
        builder.Property(x => x.ZipCode)
            .HasColumnName("cep")
            .HasColumnType("varchar(8)");
        
        builder.Property(x => x.Street)
            .HasColumnName("logradouro")
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.Number)
            .HasColumnName("numero")
            .HasColumnType("int");
        
        builder.Property(x => x.Complement)
            .HasColumnName("complemento")
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.Neighborhood)
            .HasColumnName("bairro")
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.City)
            .HasColumnName("cidade")
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.State)
            .HasColumnName("estado")
            .HasColumnType("varchar(255)");

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Adresses)
            .HasForeignKey(x => x.CompanyId);
    }
}