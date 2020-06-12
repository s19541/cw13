using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdKlient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobCukierniczy", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Clients_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Clients",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Pracownik_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownik",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczy",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false),
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie_WyrobCukierniczy", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_IdWyrobuCukierniczego",
                        column: x => x.IdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczy",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Norbert", "Gierczak" },
                    { 2, "Łukasz", "Zygmunciak" }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Paweł", "Szabla" },
                    { 2, "Łukasz", "Tak" }
                });

            migrationBuilder.InsertData(
                table: "WyrobCukierniczy",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 5f, "sernik", "ciasto" },
                    { 2, 8f, "szarlotka", "ciasto" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 3, new DateTime(2020, 6, 11, 13, 8, 42, 50, DateTimeKind.Local).AddTicks(750), new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2020, 6, 11, 13, 8, 42, 45, DateTimeKind.Local).AddTicks(9346), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienie",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 2, new DateTime(2020, 6, 11, 13, 8, 42, 50, DateTimeKind.Local).AddTicks(688), new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 3, 2, 7, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 1, 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobCukierniczy",
                columns: new[] { "IdZamowienia", "IdWyrobuCukierniczego", "Ilosc", "Uwagi" },
                values: new object[] { 2, 2, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Zamowienie",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownik",
                table: "Zamowienie",
                column: "IdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_IdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdWyrobuCukierniczego");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Pracownik");
        }
    }
}
