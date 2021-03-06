﻿// <auto-generated />
using System;
using BangBangFuli.H5.API.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(CouponSystemDBContext))]
    [Migration("20191207052435_modifyproduct")]
    partial class modifyproduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatchId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.BannerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BannerId");

                    b.Property<string>("PhotoPath");

                    b.HasKey("Id");

                    b.HasIndex("BannerId");

                    b.ToTable("BannerDetails");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.BatchInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatchId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BatchInformations");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvaliableCount");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("TotalCount");

                    b.Property<DateTime>("ValidityDate");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Contactor")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DeliveryNumber");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("ZipCode")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("ProductCount")
                        .HasMaxLength(10);

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhotoPath");

                    b.Property<int>("ProductInformationId");

                    b.HasKey("Id");

                    b.HasIndex("ProductInformationId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.ProductInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatchId");

                    b.Property<string>("Description");

                    b.Property<string>("ProductCode");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int>("ProductStatus");

                    b.Property<int>("StockType");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProductInformations");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("SupplierName");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Pass");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisteredTime");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.BannerDetail", b =>
                {
                    b.HasOne("BangBangFuli.H5.API.Core.Entities.Banner")
                        .WithMany("BannerDetails")
                        .HasForeignKey("BannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("BangBangFuli.H5.API.Core.Entities.Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangBangFuli.H5.API.Core.Entities.ProductDetail", b =>
                {
                    b.HasOne("BangBangFuli.H5.API.Core.Entities.ProductInformation")
                        .WithMany("Details")
                        .HasForeignKey("ProductInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
