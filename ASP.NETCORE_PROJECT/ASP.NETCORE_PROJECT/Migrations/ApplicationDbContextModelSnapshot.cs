﻿// <auto-generated />
using System;
using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETCORE_PROJECT.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Brand", b =>
                {
                    b.Property<Guid>("brand_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("brand_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("brand_id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Category", b =>
                {
                    b.Property<Guid>("cate_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("cate_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cate_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cate_id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Comment", b =>
                {
                    b.Property<Guid>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comment_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("comment_createdon")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("comment_productid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comment_userid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("comment_id");

                    b.HasIndex("comment_productid");

                    b.HasIndex("comment_userid");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Order", b =>
                {
                    b.Property<Guid>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("order_UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("order_createat")
                        .HasColumnType("datetime2");

                    b.Property<string>("order_note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("order_totalbill")
                        .HasColumnType("float");

                    b.HasKey("order_id");

                    b.HasIndex("order_UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("orderdetail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("orderdetail_orderid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("orderdetail_productid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("orderdetail_quantity")
                        .HasColumnType("float");

                    b.HasKey("orderdetail_id");

                    b.HasIndex("orderdetail_orderid");

                    b.HasIndex("orderdetail_productid");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Product", b =>
                {
                    b.Property<Guid>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("product_backcamera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_battery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("product_brandid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("product_cateid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("product_color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_face")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_feature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_frontcamera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_graphiccard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_operatingsystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("product_price")
                        .HasColumnType("int");

                    b.Property<int>("product_quantity")
                        .HasColumnType("int");

                    b.Property<string>("product_ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_screen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_sim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_size_volume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("product_typeid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("product_yearofmanufacturer")
                        .HasColumnType("int");

                    b.HasKey("product_id");

                    b.HasIndex("product_brandid");

                    b.HasIndex("product_cateid");

                    b.HasIndex("product_typeid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.TypeLaptop", b =>
                {
                    b.Property<Guid>("typeLaptop_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("typeLaptop_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeLaptop_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeLaptop_id");

                    b.ToTable("TypeLaptop");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Comment", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("comment_productid");

                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("comment_userid");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Order", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Orders")
                        .HasForeignKey("order_UserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.OrderDetail", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("orderdetail_orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NETCORE_PROJECT.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("orderdetail_productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Product", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Models.Brand", "brand")
                        .WithMany("Products")
                        .HasForeignKey("product_brandid");

                    b.HasOne("ASP.NETCORE_PROJECT.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("product_cateid");

                    b.HasOne("ASP.NETCORE_PROJECT.Models.TypeLaptop", "typelaptop")
                        .WithMany("Products")
                        .HasForeignKey("product_typeid");

                    b.Navigation("brand");

                    b.Navigation("category");

                    b.Navigation("typelaptop");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ASP.NETCORE_PROJECT.Models.TypeLaptop", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
