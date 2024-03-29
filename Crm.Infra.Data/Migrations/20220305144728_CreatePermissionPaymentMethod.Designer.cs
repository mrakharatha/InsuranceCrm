﻿// <auto-generated />
using System;
using Crm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crm.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220305144728_CreatePermissionPaymentMethod")]
    partial class CreatePermissionPaymentMethod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Crm.Domain.Models.Customer.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirthSpouse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfMarriageAnniversary")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("MaritalStatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Crm.Domain.Models.Insurance.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsuranceId"), 1L, 1);

                    b.Property<int?>("Code")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InsuranceId");

                    b.HasIndex("UserId");

                    b.ToTable("Insurance");
                });

            modelBuilder.Entity("Crm.Domain.Models.MaritalStatus.MaritalStatus", b =>
                {
                    b.Property<int>("MaritalStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaritalStatusId"), 1L, 1);

                    b.Property<int?>("Code")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MaritalStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("Crm.Domain.Models.PaymentMethod.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentMethodId"), 1L, 1);

                    b.Property<int?>("Code")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentId");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Title = "داشبورد"
                        },
                        new
                        {
                            PermissionId = 2,
                            Title = "تنظییمات"
                        },
                        new
                        {
                            PermissionId = 3,
                            ParentId = 2,
                            Title = "کاربران"
                        },
                        new
                        {
                            PermissionId = 4,
                            ParentId = 3,
                            Title = "افزودن کاربر"
                        },
                        new
                        {
                            PermissionId = 5,
                            ParentId = 3,
                            Title = "ویرایش کاربر "
                        },
                        new
                        {
                            PermissionId = 6,
                            ParentId = 3,
                            Title = "حذف کاربر"
                        },
                        new
                        {
                            PermissionId = 7,
                            ParentId = 2,
                            Title = "سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 8,
                            ParentId = 7,
                            Title = "افزودن سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 9,
                            ParentId = 7,
                            Title = "ویرایش سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 10,
                            ParentId = 7,
                            Title = "حذف سطح دسترسی"
                        },
                        new
                        {
                            PermissionId = 11,
                            Title = "تعاریف"
                        },
                        new
                        {
                            PermissionId = 12,
                            ParentId = 11,
                            Title = "وضعیت تاهل"
                        },
                        new
                        {
                            PermissionId = 13,
                            ParentId = 12,
                            Title = "افزودن وضعیت تاهل"
                        },
                        new
                        {
                            PermissionId = 14,
                            ParentId = 12,
                            Title = "ویرایش وضعیت تاهل "
                        },
                        new
                        {
                            PermissionId = 15,
                            ParentId = 12,
                            Title = "حذف وضعیت تاهل"
                        },
                        new
                        {
                            PermissionId = 16,
                            Title = "مشتریان"
                        },
                        new
                        {
                            PermissionId = 17,
                            ParentId = 16,
                            Title = "افزودن مشتری"
                        },
                        new
                        {
                            PermissionId = 18,
                            ParentId = 16,
                            Title = "ویرایش مشتری "
                        },
                        new
                        {
                            PermissionId = 19,
                            ParentId = 16,
                            Title = "حذف مشتری"
                        },
                        new
                        {
                            PermissionId = 20,
                            ParentId = 11,
                            Title = "بیمه"
                        },
                        new
                        {
                            PermissionId = 21,
                            ParentId = 20,
                            Title = "افزودن بیمه"
                        },
                        new
                        {
                            PermissionId = 22,
                            ParentId = 20,
                            Title = "ویرایش بیمه "
                        },
                        new
                        {
                            PermissionId = 23,
                            ParentId = 20,
                            Title = "حذف بیمه"
                        },
                        new
                        {
                            PermissionId = 24,
                            ParentId = 11,
                            Title = "روش پرداخت"
                        },
                        new
                        {
                            PermissionId = 25,
                            ParentId = 24,
                            Title = "افزودن روش پرداخت"
                        },
                        new
                        {
                            PermissionId = 26,
                            ParentId = 24,
                            Title = "ویرایش روش پرداخت "
                        },
                        new
                        {
                            PermissionId = 27,
                            ParentId = 24,
                            Title = "حذف روش پرداخت"
                        });
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolePermissionId"), 1L, 1);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Crm.Domain.Models.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreateDate = new DateTime(2022, 3, 2, 19, 56, 32, 968, DateTimeKind.Local).AddTicks(1379),
                            IsActive = true,
                            Name = "سید محمد رضا آزاد",
                            Password = "zlccbhGKkL1OKwMSZApYsIdBeTLlMwWoh573hL/kKaI=",
                            UserName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Crm.Domain.Models.User.UserRole", b =>
                {
                    b.Property<int>("UR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UR_Id"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Crm.Domain.Models.Customer.Customer", b =>
                {
                    b.HasOne("Crm.Domain.Models.MaritalStatus.MaritalStatus", "MaritalStatus")
                        .WithMany("Customers")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.User.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MaritalStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crm.Domain.Models.Insurance.Insurance", b =>
                {
                    b.HasOne("Crm.Domain.Models.User.User", "User")
                        .WithMany("Insurances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crm.Domain.Models.MaritalStatus.MaritalStatus", b =>
                {
                    b.HasOne("Crm.Domain.Models.User.User", "User")
                        .WithMany("MaritalStatus")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crm.Domain.Models.PaymentMethod.PaymentMethod", b =>
                {
                    b.HasOne("Crm.Domain.Models.User.User", "User")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.Permission", b =>
                {
                    b.HasOne("Crm.Domain.Models.Permissions.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.RolePermission", b =>
                {
                    b.HasOne("Crm.Domain.Models.Permissions.Permission", "Permission")
                        .WithMany("RolePermission")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.Permissions.Role", "Role")
                        .WithMany("RolePermission")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Crm.Domain.Models.User.UserRole", b =>
                {
                    b.HasOne("Crm.Domain.Models.Permissions.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Models.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Crm.Domain.Models.MaritalStatus.MaritalStatus", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Crm.Domain.Models.Permissions.Role", b =>
                {
                    b.Navigation("RolePermission");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Crm.Domain.Models.User.User", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Insurances");

                    b.Navigation("MaritalStatus");

                    b.Navigation("PaymentMethods");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
