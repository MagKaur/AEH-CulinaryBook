﻿// <auto-generated />
using CulinaryBook.ConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CulinaryBook.ConsoleApp.Migrations
{
    [DbContext(typeof(CulinaryBookContext))]
    [Migration("20210602191632_migrate-02-06-2021")]
    partial class migrate02062021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AUTHOR");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("BOOK");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("CATEGORY");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Junit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("INGREDIENT");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.IngredientsList", b =>
                {
                    b.Property<int>("Id_Recipe")
                        .HasColumnType("int");

                    b.Property<int>("Id_Ingredient")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id_Recipe", "Id_Ingredient");

                    b.HasIndex("Id_Ingredient");

                    b.ToTable("INGREDIENTS_LIST");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Author")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Id_Author")
                        .IsUnique();

                    b.ToTable("RECIPE");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.RecipesList", b =>
                {
                    b.Property<int>("Id_Recipe")
                        .HasColumnType("int");

                    b.Property<int>("Id_Category")
                        .HasColumnType("int");

                    b.Property<int>("Id_Book")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("Id_Recipe", "Id_Category", "Id_Book");

                    b.HasIndex("Id_Book");

                    b.HasIndex("Id_Category");

                    b.ToTable("RECIPES_LIST");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Step", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("STEP");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.StepsList", b =>
                {
                    b.Property<int>("Id_Recipe")
                        .HasColumnType("int");

                    b.Property<int>("Id_Step")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Step_Number")
                        .HasColumnType("int");

                    b.HasKey("Id_Recipe", "Id_Step");

                    b.HasIndex("Id_Step");

                    b.ToTable("STEPS_LIST");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.IngredientsList", b =>
                {
                    b.HasOne("CulinaryBook.ConsoleApp.Models.Ingredient", "Ingredient")
                        .WithMany("IngredientsLists")
                        .HasForeignKey("Id_Ingredient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CulinaryBook.ConsoleApp.Models.Recipe", "Recipe")
                        .WithMany("IngredientsLists")
                        .HasForeignKey("Id_Recipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Recipe", b =>
                {
                    b.HasOne("CulinaryBook.ConsoleApp.Author", "Author")
                        .WithOne("Recipe")
                        .HasForeignKey("CulinaryBook.ConsoleApp.Models.Recipe", "Id_Author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.RecipesList", b =>
                {
                    b.HasOne("CulinaryBook.ConsoleApp.Models.Book", "Book")
                        .WithMany("RecipesLists")
                        .HasForeignKey("Id_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CulinaryBook.ConsoleApp.Models.Category", "Category")
                        .WithMany("RecipesLists")
                        .HasForeignKey("Id_Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CulinaryBook.ConsoleApp.Models.Recipe", "Recipe")
                        .WithMany("RecipesLists")
                        .HasForeignKey("Id_Recipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.StepsList", b =>
                {
                    b.HasOne("CulinaryBook.ConsoleApp.Models.Recipe", "Recipe")
                        .WithMany("StepsLists")
                        .HasForeignKey("Id_Recipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CulinaryBook.ConsoleApp.Models.Step", "Step")
                        .WithMany("StepsLists")
                        .HasForeignKey("Id_Step")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Author", b =>
                {
                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Book", b =>
                {
                    b.Navigation("RecipesLists");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Category", b =>
                {
                    b.Navigation("RecipesLists");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Ingredient", b =>
                {
                    b.Navigation("IngredientsLists");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Recipe", b =>
                {
                    b.Navigation("IngredientsLists");

                    b.Navigation("RecipesLists");

                    b.Navigation("StepsLists");
                });

            modelBuilder.Entity("CulinaryBook.ConsoleApp.Models.Step", b =>
                {
                    b.Navigation("StepsLists");
                });
#pragma warning restore 612, 618
        }
    }
}
