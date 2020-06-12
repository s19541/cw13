using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class dbsetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_Clients_IdKlient",
                table: "Zamowienie");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_Pracownik_IdPracownik",
                table: "Zamowienie");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_IdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_IdZamowienia",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienie_WyrobCukierniczy",
                table: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WyrobCukierniczy",
                table: "WyrobCukierniczy");

            migrationBuilder.RenameTable(
                name: "Zamowienie_WyrobCukierniczy",
                newName: "OrdersProducts");

            migrationBuilder.RenameTable(
                name: "Zamowienie",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "WyrobCukierniczy",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_IdWyrobuCukierniczego",
                table: "OrdersProducts",
                newName: "IX_OrdersProducts_IdWyrobuCukierniczego");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienie_IdPracownik",
                table: "Orders",
                newName: "IX_Orders_IdPracownik");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienie_IdKlient",
                table: "Orders",
                newName: "IX_Orders_IdKlient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                column: "IdZamowienia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "IdZamowienia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "IdWyrobuCukierniczego");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 34, 28, 351, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 34, 28, 354, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 34, 28, 354, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_IdKlient",
                table: "Orders",
                column: "IdKlient",
                principalTable: "Clients",
                principalColumn: "IdKlient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pracownik_IdPracownik",
                table: "Orders",
                column: "IdPracownik",
                principalTable: "Pracownik",
                principalColumn: "IdPracownik",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_IdWyrobuCukierniczego",
                table: "OrdersProducts",
                column: "IdWyrobuCukierniczego",
                principalTable: "Products",
                principalColumn: "IdWyrobuCukierniczego",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_IdZamowienia",
                table: "OrdersProducts",
                column: "IdZamowienia",
                principalTable: "Orders",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_IdKlient",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pracownik_IdPracownik",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_IdWyrobuCukierniczego",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Orders_IdZamowienia",
                table: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "WyrobCukierniczy");

            migrationBuilder.RenameTable(
                name: "OrdersProducts",
                newName: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Zamowienie");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersProducts_IdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy",
                newName: "IX_Zamowienie_WyrobCukierniczy_IdWyrobuCukierniczego");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdPracownik",
                table: "Zamowienie",
                newName: "IX_Zamowienie_IdPracownik");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdKlient",
                table: "Zamowienie",
                newName: "IX_Zamowienie_IdKlient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WyrobCukierniczy",
                table: "WyrobCukierniczy",
                column: "IdWyrobuCukierniczego");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienie_WyrobCukierniczy",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdZamowienia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zamowienie",
                table: "Zamowienie",
                column: "IdZamowienia");

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 8, 42, 45, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 8, 42, 50, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Zamowienie",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 11, 13, 8, 42, 50, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_Clients_IdKlient",
                table: "Zamowienie",
                column: "IdKlient",
                principalTable: "Clients",
                principalColumn: "IdKlient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_Pracownik_IdPracownik",
                table: "Zamowienie",
                column: "IdPracownik",
                principalTable: "Pracownik",
                principalColumn: "IdPracownik",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_WyrobCukierniczy_IdWyrobuCukierniczego",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdWyrobuCukierniczego",
                principalTable: "WyrobCukierniczy",
                principalColumn: "IdWyrobuCukierniczego",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_WyrobCukierniczy_Zamowienie_IdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdZamowienia",
                principalTable: "Zamowienie",
                principalColumn: "IdZamowienia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
