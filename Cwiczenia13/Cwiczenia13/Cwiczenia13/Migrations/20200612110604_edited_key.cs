using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia13.Migrations
{
    public partial class edited_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_IdWyrobuCukierniczego",
                table: "OrdersProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 6, 4, 479, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 6, 4, 482, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 6, 4, 482, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_IdZamowienia",
                table: "OrdersProducts",
                column: "IdZamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_IdZamowienia",
                table: "OrdersProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                column: "IdZamowienia");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 3, 33, 2, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 3, 33, 5, DateTimeKind.Local).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "IdZamowienia",
                keyValue: 3,
                column: "DataPrzyjecia",
                value: new DateTime(2020, 6, 12, 13, 3, 33, 5, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_IdWyrobuCukierniczego",
                table: "OrdersProducts",
                column: "IdWyrobuCukierniczego");
        }
    }
}
