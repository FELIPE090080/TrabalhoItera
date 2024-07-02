using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho.API.Migrations
{
    /// <inheritdoc />
    public partial class criacaoBancoDeDados1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoteCliente_Cliente_ClienteId",
                table: "LoteCliente");

            migrationBuilder.DropIndex(
                name: "IX_LoteCliente_ClienteId",
                table: "LoteCliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoteCliente",
                newName: "LoteClienteID");

            migrationBuilder.AlterColumn<int>(
                name: "LoteClienteID",
                table: "LoteCliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoteCliente_Cliente_LoteClienteID",
                table: "LoteCliente",
                column: "LoteClienteID",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoteCliente_Cliente_LoteClienteID",
                table: "LoteCliente");

            migrationBuilder.RenameColumn(
                name: "LoteClienteID",
                table: "LoteCliente",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LoteCliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_LoteCliente_ClienteId",
                table: "LoteCliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoteCliente_Cliente_ClienteId",
                table: "LoteCliente",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
