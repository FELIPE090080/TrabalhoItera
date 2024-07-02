using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho.API.Migrations
{
    /// <inheritdoc />
    public partial class criacaoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Cliente_ClienteId",
                table: "Lote");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Lote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LoteCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoteId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoteCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoteCliente_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoteCliente_ClienteId",
                table: "LoteCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LoteCliente_LoteId",
                table: "LoteCliente",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Cliente_ClienteId",
                table: "Lote",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Cliente_ClienteId",
                table: "Lote");

            migrationBuilder.DropTable(
                name: "LoteCliente");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Lote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Cliente_ClienteId",
                table: "Lote",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
