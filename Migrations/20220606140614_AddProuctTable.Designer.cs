﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductionManagment.Data;

#nullable disable

namespace ProductionManagment.Migrations
{
    [DbContext(typeof(ProductionManagmentContext))]
    [Migration("20220606140614_AddProuctTable")]
    partial class AddProuctTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductionManagment.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("CostOfWorkingHour")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TransportCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ProductionManagment.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AssemblyTime")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SearchHistoryId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SearchHistoryId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("ProductionManagment.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Modules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductionManagment.Models.SearchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ModuleName1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleName3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleName4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductionCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.ToTable("SearchHistory");
                });

            modelBuilder.Entity("ProductionManagment.Models.Module", b =>
                {
                    b.HasOne("ProductionManagment.Models.SearchHistory", "SearchHistory")
                        .WithMany()
                        .HasForeignKey("SearchHistoryId");

                    b.Navigation("SearchHistory");
                });

            modelBuilder.Entity("ProductionManagment.Models.Product", b =>
                {
                    b.HasOne("ProductionManagment.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ProductionManagment.Models.SearchHistory", b =>
                {
                    b.HasOne("ProductionManagment.Models.City", null)
                        .WithOne("SearchHistory")
                        .HasForeignKey("ProductionManagment.Models.SearchHistory", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductionManagment.Models.City", b =>
                {
                    b.Navigation("SearchHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
