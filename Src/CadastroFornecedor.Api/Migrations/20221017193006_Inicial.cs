using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroFornecedor.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    Cnpj_Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco_Numero = table.Column<string>(type: "TEXT", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Excluido = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
