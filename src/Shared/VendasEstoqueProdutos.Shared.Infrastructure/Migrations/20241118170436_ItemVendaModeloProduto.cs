using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasEstoqueProdutos.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemVendaModeloProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemVendas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_ModeloProdutoId",
                table: "ItemVendas",
                column: "ModeloProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_ModeloProdutos_ModeloProdutoId",
                table: "ItemVendas",
                column: "ModeloProdutoId",
                principalTable: "ModeloProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_ModeloProdutos_ModeloProdutoId",
                table: "ItemVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_ModeloProdutoId",
                table: "ItemVendas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItemVendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
