using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTime",
                table: "SalesTransactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SalesTransactions",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTime",
                table: "SalesTransactions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "SalesTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTime",
                table: "SalesTransactions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SalesTransactions");

            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "SalesTransactions");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SalesTransactions");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "SalesTransactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTime",
                table: "SalesTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
