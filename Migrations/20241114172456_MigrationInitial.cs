using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniAPISystem.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UlogaId1",
                table: "Korisnici",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaId1",
                table: "Korisnici",
                column: "UlogaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Uloge_UlogaId1",
                table: "Korisnici",
                column: "UlogaId1",
                principalTable: "Uloge",
                principalColumn: "UlogaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Uloge_UlogaId1",
                table: "Korisnici");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_UlogaId1",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "UlogaId1",
                table: "Korisnici");
        }
    }
}
