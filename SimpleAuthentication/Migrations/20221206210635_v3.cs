using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$tAqasmxnBhm0i6Kelv7KI.3cJFwdADIZpesecCAt3wW2LJ3c5IvMu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$ZYVCciahbmJ9BP9YW8Qj8eWp4o0CoE5HqCaA3piIqTkQYUxm2FknC");
        }
    }
}
