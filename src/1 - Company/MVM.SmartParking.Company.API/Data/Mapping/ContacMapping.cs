using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data.Mapping;

public class ContacMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contatos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)");
        
        builder.Property(x => x.Code)
            .HasColumnName("ddd")
            .HasColumnType("varchar(2)");
        
        builder.Property(x => x.Telephone)
            .HasColumnName("telefone")
            .HasColumnType("varchar(9)");

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.CompanyId);
    }
}