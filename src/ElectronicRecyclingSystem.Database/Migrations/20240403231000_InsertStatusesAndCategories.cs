using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicRecyclingSystem.Database.Migrations;

public partial class InsertStatusesAndCategories : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "recycling_application_statuses",
            columns: new []{"id", "name"},
            values: new object[,]
            {
                {1, "Created"},
                {2, "Received"},
                {3, "Closed"},
                {4, "Cancelled"},
            });
        
        migrationBuilder.InsertData(
            table: "electronic_devices_categories",
            columns: new []{"id", "name"},
            values: new object[,]
            {
                {0, "Other"},
                {1, "Mobile Phones"},
                {2, "Laptops"},
                {3, "Cameras"},
                {4, "Monitors"},
            });
    }
}