using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopConsultant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilterCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenSize = table.Column<double>(type: "float", nullable: true),
                    RAM = table.Column<int>(type: "int", nullable: true),
                    SSD = table.Column<int>(type: "int", nullable: true),
                    MaxWeight = table.Column<double>(type: "float", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Needs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Brands = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    SSD = table.Column<int>(type: "int", nullable: false),
                    ScreenSize = table.Column<double>(type: "float", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterCriteriaCPUs",
                columns: table => new
                {
                    FilterCriteriaId = table.Column<int>(type: "int", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterCriteriaCPUs", x => new { x.FilterCriteriaId, x.CPU });
                    table.ForeignKey(
                        name: "FK_FilterCriteriaCPUs_FilterCriterias_FilterCriteriaId",
                        column: x => x.FilterCriteriaId,
                        principalTable: "FilterCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterCriteriaGPUs",
                columns: table => new
                {
                    FilterCriteriaId = table.Column<int>(type: "int", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterCriteriaGPUs", x => new { x.FilterCriteriaId, x.GPU });
                    table.ForeignKey(
                        name: "FK_FilterCriteriaGPUs_FilterCriterias_FilterCriteriaId",
                        column: x => x.FilterCriteriaId,
                        principalTable: "FilterCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaptopNeeds",
                columns: table => new
                {
                    LaptopId = table.Column<int>(type: "int", nullable: false),
                    Need = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopNeeds", x => new { x.LaptopId, x.Need });
                    table.ForeignKey(
                        name: "FK_LaptopNeeds_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SelectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectedLaptopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSelections_Laptops_SelectedLaptopId",
                        column: x => x.SelectedLaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSelectionBrands",
                columns: table => new
                {
                    UserSelectionId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectionBrands", x => new { x.UserSelectionId, x.Brand });
                    table.ForeignKey(
                        name: "FK_UserSelectionBrands_UserSelections_UserSelectionId",
                        column: x => x.UserSelectionId,
                        principalTable: "UserSelections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSelectionNeeds",
                columns: table => new
                {
                    UserSelectionId = table.Column<int>(type: "int", nullable: false),
                    Need = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectionNeeds", x => new { x.UserSelectionId, x.Need });
                    table.ForeignKey(
                        name: "FK_UserSelectionNeeds_UserSelections_UserSelectionId",
                        column: x => x.UserSelectionId,
                        principalTable: "UserSelections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_SelectedLaptopId",
                table: "UserSelections",
                column: "SelectedLaptopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterCriteriaCPUs");

            migrationBuilder.DropTable(
                name: "FilterCriteriaGPUs");

            migrationBuilder.DropTable(
                name: "LaptopNeeds");

            migrationBuilder.DropTable(
                name: "UserSelectionBrands");

            migrationBuilder.DropTable(
                name: "UserSelectionNeeds");

            migrationBuilder.DropTable(
                name: "FilterCriterias");

            migrationBuilder.DropTable(
                name: "UserSelections");

            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
