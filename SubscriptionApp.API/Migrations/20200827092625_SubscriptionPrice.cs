using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionApp.API.Migrations
{
    public partial class SubscriptionPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubscriptionPrice",
                table: "Subscriptions",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionPrice",
                table: "Subscriptions");
        }
    }
}
