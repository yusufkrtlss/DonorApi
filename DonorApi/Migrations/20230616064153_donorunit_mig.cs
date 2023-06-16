using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonorApi.Migrations
{
    public partial class donorunit_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_AddBlood_AddBloodId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "AddBlood");

            migrationBuilder.DropIndex(
                name: "IX_Donors_AddBloodId",
                table: "Donors");

            migrationBuilder.RenameColumn(
                name: "AddBloodId",
                table: "Donors",
                newName: "Unit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Donors",
                newName: "AddBloodId");

            migrationBuilder.CreateTable(
                name: "AddBlood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddBlood", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_AddBloodId",
                table: "Donors",
                column: "AddBloodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_AddBlood_AddBloodId",
                table: "Donors",
                column: "AddBloodId",
                principalTable: "AddBlood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
