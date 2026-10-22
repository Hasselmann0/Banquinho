using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banquinho.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RefineCustomerEnterpriseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Accounts",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Enterprises",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LegalRepresentativeId",
                table: "Enterprises",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_LegalRepresentativeId",
                table: "Enterprises",
                column: "LegalRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_Customers_LegalRepresentativeId",
                table: "Enterprises",
                column: "LegalRepresentativeId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_Customers_LegalRepresentativeId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_LegalRepresentativeId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "LegalRepresentativeId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Accounts",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Customers",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);
        }
    }
}
