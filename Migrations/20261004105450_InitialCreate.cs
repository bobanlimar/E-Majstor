using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMajstor.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majstori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", nullable: false),
                    Zanimanje = table.Column<string>(type: "TEXT", nullable: false),
                    BrojTelefona = table.Column<string>(type: "TEXT", nullable: false),
                    Grad = table.Column<string>(type: "TEXT", nullable: false),
                    CenaPoSatu = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majstori", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Majstori");
        }
    }
}
