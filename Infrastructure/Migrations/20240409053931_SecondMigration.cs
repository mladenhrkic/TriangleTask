using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "Triangles",
                columns: table => new
                {
                    TriangleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SideA = table.Column<double>(type: "REAL", nullable: false),
                    SideB = table.Column<double>(type: "REAL", nullable: false),
                    SideC = table.Column<double>(type: "REAL", nullable: false),
                    GammaAngle = table.Column<double>(type: "REAL", nullable: false),
                    AlphaAngle = table.Column<double>(type: "REAL", nullable: false),
                    BetaAngle = table.Column<double>(type: "REAL", nullable: false),
                    Perimeter = table.Column<double>(type: "REAL", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triangles", x => x.TriangleId);
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "Category");

         

            
        }
    }
}
