﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.WebApi.Class06.CodeFirst.Domain;

#nullable disable

namespace SEDC.WebApi.Class06.CodeFirst.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("OrderAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaTypeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.PizzaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PizzaTypes");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("000000");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Temnica",
                            City = "Skopje",
                            Email = "a@b.com.mk",
                            Name = "Trajan"
                        });
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Order", b =>
                {
                    b.HasOne("SEDC.WebApi.Class06.CodeFirst.Domain.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SEDC.WebApi.Class06.CodeFirst.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.OrderDetail", b =>
                {
                    b.HasOne("SEDC.WebApi.Class06.CodeFirst.Domain.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.WebApi.Class06.CodeFirst.Domain.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Pizza", b =>
                {
                    b.HasOne("SEDC.WebApi.Class06.CodeFirst.Domain.PizzaType", "PizzaType")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaType");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.Pizza", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.PizzaType", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("SEDC.WebApi.Class06.CodeFirst.Domain.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
