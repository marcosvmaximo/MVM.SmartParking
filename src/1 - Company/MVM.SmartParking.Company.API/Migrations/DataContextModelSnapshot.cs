﻿// <auto-generated />
using System;
using MVM.SmartParking.Company.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVM.SmartParking.Company.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("cidade");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("complemento");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("bairro");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("estado");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("logradouro");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nome");

                    b.Property<int>("NumberCarSpace")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_vagas_carro");

                    b.Property<int>("NumberMotoSpace")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_vagas_moto");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("password_hash");

                    b.Property<sbyte>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("ddd");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("varchar(9)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contatos", (string)null);
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.PriceRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("PriceForTime")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("preco_por_tempo");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time")
                        .HasColumnName("tempo");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Regras_Tempo", (string)null);
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Adress", b =>
                {
                    b.HasOne("MVM.SmartParking.Company.API.Models.Company", "Company")
                        .WithMany("Adresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Contact", b =>
                {
                    b.HasOne("MVM.SmartParking.Company.API.Models.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.PriceRule", b =>
                {
                    b.HasOne("MVM.SmartParking.Company.API.Models.Company", "Company")
                        .WithMany("PriceRules")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MVM.SmartParking.Company.API.Models.Company", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Contacts");

                    b.Navigation("PriceRules");
                });
#pragma warning restore 612, 618
        }
    }
}
