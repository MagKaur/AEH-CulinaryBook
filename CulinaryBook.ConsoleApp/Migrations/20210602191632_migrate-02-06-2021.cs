﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CulinaryBook.ConsoleApp.Migrations
{
    public partial class migrate02062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TYPE",
                table: "AUTHOR",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "AUTHOR",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "AUTHOR",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LOGIN",
                table: "AUTHOR",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "AUTHOR",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "AUTHOR",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Junit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RECIPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Author = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECIPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RECIPE_AUTHOR_Id_Author",
                        column: x => x.Id_Author,
                        principalTable: "AUTHOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STEP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STEP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENTS_LIST",
                columns: table => new
                {
                    Id_Ingredient = table.Column<int>(type: "int", nullable: false),
                    Id_Recipe = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTS_LIST", x => new { x.Id_Recipe, x.Id_Ingredient });
                    table.ForeignKey(
                        name: "FK_INGREDIENTS_LIST_INGREDIENT_Id_Ingredient",
                        column: x => x.Id_Ingredient,
                        principalTable: "INGREDIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INGREDIENTS_LIST_RECIPE_Id_Recipe",
                        column: x => x.Id_Recipe,
                        principalTable: "RECIPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RECIPES_LIST",
                columns: table => new
                {
                    Id_Recipe = table.Column<int>(type: "int", nullable: false),
                    Id_Category = table.Column<int>(type: "int", nullable: false),
                    Id_Book = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECIPES_LIST", x => new { x.Id_Recipe, x.Id_Category, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_RECIPES_LIST_BOOK_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "BOOK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RECIPES_LIST_CATEGORY_Id_Category",
                        column: x => x.Id_Category,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RECIPES_LIST_RECIPE_Id_Recipe",
                        column: x => x.Id_Recipe,
                        principalTable: "RECIPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STEPS_LIST",
                columns: table => new
                {
                    Id_Step = table.Column<int>(type: "int", nullable: false),
                    Id_Recipe = table.Column<int>(type: "int", nullable: false),
                    Step_Number = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STEPS_LIST", x => new { x.Id_Recipe, x.Id_Step });
                    table.ForeignKey(
                        name: "FK_STEPS_LIST_RECIPE_Id_Recipe",
                        column: x => x.Id_Recipe,
                        principalTable: "RECIPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STEPS_LIST_STEP_Id_Step",
                        column: x => x.Id_Step,
                        principalTable: "STEP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INGREDIENTS_LIST_Id_Ingredient",
                table: "INGREDIENTS_LIST",
                column: "Id_Ingredient");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_Id_Author",
                table: "RECIPE",
                column: "Id_Author",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_LIST_Id_Book",
                table: "RECIPES_LIST",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_LIST_Id_Category",
                table: "RECIPES_LIST",
                column: "Id_Category");

            migrationBuilder.CreateIndex(
                name: "IX_STEPS_LIST_Id_Step",
                table: "STEPS_LIST",
                column: "Id_Step");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INGREDIENTS_LIST");

            migrationBuilder.DropTable(
                name: "RECIPES_LIST");

            migrationBuilder.DropTable(
                name: "STEPS_LIST");

            migrationBuilder.DropTable(
                name: "INGREDIENT");

            migrationBuilder.DropTable(
                name: "BOOK");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "RECIPE");

            migrationBuilder.DropTable(
                name: "STEP");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AUTHOR",
                newName: "TYPE");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AUTHOR",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AUTHOR",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "AUTHOR",
                newName: "LOGIN");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AUTHOR",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AUTHOR",
                newName: "DESCRIPTION");
        }
    }
}
