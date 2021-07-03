using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class cityMater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityMasters",
                columns: table => new
                {
                    Cityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMasters", x => x.Cityid);
                    table.ForeignKey(
                        name: "FK_CityMasters_CountryMasters_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryMasters",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityMasters_StateMasters_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMasters",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_CountryId",
                table: "CityMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_StateId",
                table: "CityMasters",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityMasters");
        }
    }
}
