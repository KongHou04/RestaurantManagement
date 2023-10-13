using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Employee_EmployeeID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_EmployeeID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employee",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Username",
                table: "Employee",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Account_Username",
                table: "Employee",
                column: "Username",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Account_Username",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Username",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Account_EmployeeID",
                table: "Account",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Employee_EmployeeID",
                table: "Account",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
