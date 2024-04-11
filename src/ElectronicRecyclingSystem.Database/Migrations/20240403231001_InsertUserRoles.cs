using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicRecyclingSystem.Database.Migrations;

public partial class InsertUserRoles : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "user_roles",
            columns: new []{"id", "role"},
            values: new object[,]
            {
                {1, "Client"},
                {2, "Worker"}
            });
    }
}