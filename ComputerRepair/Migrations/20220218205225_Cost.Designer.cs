﻿// <auto-generated />
using System;
using ComputerRepair.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComputerRepair.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220218205225_Cost")]
    partial class Cost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ComputerEmployee", b =>
                {
                    b.Property<int>("ComputersId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("ComputersId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("ComputerEmployee");
                });

            modelBuilder.Entity("ComputerRepair.Enteties.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("ComputerRepair.Enteties.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ComputerRepair.Enteties.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComputerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Maitences");
                });

            modelBuilder.Entity("ComputerEmployee", b =>
                {
                    b.HasOne("ComputerRepair.Enteties.Computer", null)
                        .WithMany()
                        .HasForeignKey("ComputersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerRepair.Enteties.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerRepair.Enteties.Maintenance", b =>
                {
                    b.HasOne("ComputerRepair.Enteties.Computer", "Computer")
                        .WithMany("Maintenances")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });

            modelBuilder.Entity("ComputerRepair.Enteties.Computer", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
