using Microsoft.EntityFrameworkCore.Migrations;

namespace theFungiDataAccess.Migrations
{
    public partial class collumnnamechangeinAuditLogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AuditLogs",
                newName: "Identity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identity",
                table: "AuditLogs",
                newName: "Username");
        }
    }
}
