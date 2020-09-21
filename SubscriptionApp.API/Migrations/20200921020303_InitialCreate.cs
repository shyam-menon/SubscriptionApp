using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkuColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkuColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkuFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkuFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkuModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkuModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkuSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkuSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkuTitles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModelId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: true),
                    FunctionId = table.Column<int>(nullable: true),
                    SizeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkuTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PseudoSkuTitles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PseudoSkuTitles_PseudoSkuColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "PseudoSkuColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PseudoSkuTitles_PseudoSkuFunctions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "PseudoSkuFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PseudoSkuTitles_PseudoSkuModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "PseudoSkuModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PseudoSkuTitles_PseudoSkuSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "PseudoSkuSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PseudoSkus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoSkus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PseudoSkus_PseudoSkuTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "PseudoSkuTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PseudoSkuId = table.Column<int>(nullable: true),
                    SubscriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionItems_PseudoSkus_PseudoSkuId",
                        column: x => x.PseudoSkuId,
                        principalTable: "PseudoSkus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriptionItems_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkus_TitleId",
                table: "PseudoSkus",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkuTitles_CategoryId",
                table: "PseudoSkuTitles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkuTitles_ColorId",
                table: "PseudoSkuTitles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkuTitles_FunctionId",
                table: "PseudoSkuTitles",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkuTitles_ModelId",
                table: "PseudoSkuTitles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PseudoSkuTitles_SizeId",
                table: "PseudoSkuTitles",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItems_PseudoSkuId",
                table: "SubscriptionItems",
                column: "PseudoSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItems_SubscriptionId",
                table: "SubscriptionItems",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionItems");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "PseudoSkus");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "PseudoSkuTitles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PseudoSkuColors");

            migrationBuilder.DropTable(
                name: "PseudoSkuFunctions");

            migrationBuilder.DropTable(
                name: "PseudoSkuModels");

            migrationBuilder.DropTable(
                name: "PseudoSkuSize");
        }
    }
}
