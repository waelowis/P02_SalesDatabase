﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P02_SalesDatabase.Data;

#nullable disable

namespace P02_SalesDatabase.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("P02_SalesDatabase.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CreaditCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CreaditCardNumber = "1111222233334444",
                            Email = "wael.mohamed@example.com",
                            Name = "Ali Abdullah"
                        },
                        new
                        {
                            CustomerId = 2,
                            CreaditCardNumber = "5555666677778888",
                            Email = "mohamed.wael@example.com",
                            Name = "Fatima Saeed"
                        },
                        new
                        {
                            CustomerId = 3,
                            CreaditCardNumber = "9999000011112222",
                            Email = "wael_mohamed@example.com",
                            Name = "Omar Khaled"
                        });
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasDefaultValue("No description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Laptop Pro",
                            Price = 1200.00m,
                            Quantity = 100f
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Mechanical Keyboard",
                            Price = 80.50m,
                            Quantity = 250f
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Gaming Mouse",
                            Price = 45.00m,
                            Quantity = 300f
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "USB-C Hub",
                            Price = 30.00m,
                            Quantity = 150f
                        });
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SaleId = 1,
                            CustomerId = 1,
                            Date = new DateTime(2025, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1,
                            StoreId = 1
                        },
                        new
                        {
                            SaleId = 2,
                            CustomerId = 2,
                            Date = new DateTime(2025, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 2,
                            StoreId = 2
                        },
                        new
                        {
                            SaleId = 3,
                            CustomerId = 1,
                            Date = new DateTime(2025, 5, 21, 15, 15, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 3,
                            StoreId = 1
                        },
                        new
                        {
                            SaleId = 4,
                            CustomerId = 3,
                            Date = new DateTime(2025, 5, 22, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1,
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Name = "Cairo"
                        },
                        new
                        {
                            StoreId = 2,
                            Name = "Giza"
                        });
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Sale", b =>
                {
                    b.HasOne("P02_SalesDatabase.Models.Customer", "Customer")
                        .WithMany("sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P02_SalesDatabase.Models.Product", "product")
                        .WithMany("sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P02_SalesDatabase.Models.Store", "Store")
                        .WithMany("sales")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Store");

                    b.Navigation("product");
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Customer", b =>
                {
                    b.Navigation("sales");
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Product", b =>
                {
                    b.Navigation("sales");
                });

            modelBuilder.Entity("P02_SalesDatabase.Models.Store", b =>
                {
                    b.Navigation("sales");
                });
#pragma warning restore 612, 618
        }
    }
}
