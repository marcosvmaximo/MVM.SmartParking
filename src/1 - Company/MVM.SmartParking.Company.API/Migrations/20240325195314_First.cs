using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVM.SmartParking.Company.API.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cnpj = table.Column<string>(type: "varchar(14)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade_vagas_carro = table.Column<int>(type: "int", nullable: false),
                    quantidade_vagas_moto = table.Column<int>(type: "int", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ddd = table.Column<string>(type: "varchar(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "varchar(9)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contatos_Empresas_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logradouro = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    cidade = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Empresas_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regras_Tempo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    tempo = table.Column<TimeSpan>(type: "time", nullable: false),
                    preco_por_tempo = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras_Tempo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Regras_Tempo_Empresas_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_CompanyId",
                table: "Contatos",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CompanyId",
                table: "Enderecos",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Regras_Tempo_CompanyId",
                table: "Regras_Tempo",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Regras_Tempo");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
