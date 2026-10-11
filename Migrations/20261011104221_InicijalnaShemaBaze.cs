using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMajstor.API.Migrations
{
    /// <inheritdoc />
    public partial class InicijalnaShemaBaze : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "Majstori");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Majstori");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Majstori");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Majstori");

            migrationBuilder.RenameColumn(
                name: "Zanimanje",
                table: "Majstori",
                newName: "Kategorija");

            migrationBuilder.AlterColumn<decimal>(
                name: "CenaPoSatu",
                table: "Majstori",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Majstori",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Majstori",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImePrezime = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    SifraHash = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Grad = table.Column<string>(type: "TEXT", nullable: true),
                    Uloga = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MajstorId = table.Column<int>(type: "INTEGER", nullable: false),
                    NazivUsluge = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: true),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_Majstori_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Majstori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PosiljalacId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrimalacId = table.Column<int>(type: "INTEGER", nullable: false),
                    TekstPoruke = table.Column<string>(type: "TEXT", nullable: false),
                    PoslatoAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruke_Users_PosiljalacId",
                        column: x => x.PosiljalacId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poruke_Users_PrimalacId",
                        column: x => x.PrimalacId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KlijentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajstorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpisKvara = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DatumZahteva = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Users_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Users_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ZahtevId = table.Column<int>(type: "INTEGER", nullable: false),
                    KlijentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajstorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OcenaVrednost = table.Column<int>(type: "INTEGER", nullable: false),
                    Komentar = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocene_Users_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_Users_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_Zahtevi_ZahtevId",
                        column: x => x.ZahtevId,
                        principalTable: "Zahtevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majstori_UserId",
                table: "Majstori",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_KlijentId",
                table: "Ocene",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_MajstorId",
                table: "Ocene",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_ZahtevId",
                table: "Ocene",
                column: "ZahtevId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_PosiljalacId",
                table: "Poruke",
                column: "PosiljalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_PrimalacId",
                table: "Poruke",
                column: "PrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_MajstorId",
                table: "Usluge",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_KlijentId",
                table: "Zahtevi",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MajstorId",
                table: "Zahtevi",
                column: "MajstorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Majstori_Users_UserId",
                table: "Majstori",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Majstori_Users_UserId",
                table: "Majstori");

            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Zahtevi");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Majstori_UserId",
                table: "Majstori");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Majstori");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Majstori");

            migrationBuilder.RenameColumn(
                name: "Kategorija",
                table: "Majstori",
                newName: "Zanimanje");

            migrationBuilder.AlterColumn<decimal>(
                name: "CenaPoSatu",
                table: "Majstori",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "Majstori",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Majstori",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Majstori",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Majstori",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
