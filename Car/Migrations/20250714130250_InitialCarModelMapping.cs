using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Car.Migrations
{
    /// <inheritdoc />
    public partial class InitialCarModelMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arabalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    Renk = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fiyat = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DonanimSeviyesi = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arabalar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arabalar");
        }
    }
}
