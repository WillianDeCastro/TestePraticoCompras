using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
