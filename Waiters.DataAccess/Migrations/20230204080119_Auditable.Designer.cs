﻿// <auto-generated />
using System;
using DefaultTemplate.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DefaultTemplate.DataAccess.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20230204080119_Auditable")]
    partial class Auditable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.BussinessEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Businesses", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.AddressDetailEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("AddressDetails", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.ContactDetailEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("ContactDetails", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ParentId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions", "portal");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Roles", "portal");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RolePermissionEntity", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("PermissionId")
                        .HasColumnType("text");

                    b.Property<string>("PermissionEntityId")
                        .HasColumnType("text");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionEntityId");

                    b.HasIndex("PermissionId");

                    b.ToTable("Roles_Permmissions", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LoginMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("LoginMail")
                        .IsUnique();

                    b.HasIndex("ModifiedById");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.WaiterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("CreateById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("DeletedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Waiters.Api", (string)null);
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.BussinessEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("DefaultTemplate.DataAccess.Entities.Users.BussinessEntity", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.EmployeeEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("DefaultTemplate.DataAccess.Entities.Users.EmployeeEntity", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.AddressDetailEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", null)
                        .WithMany("AddressDetails")
                        .HasForeignKey("UserEntityId");

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.ContactDetailEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", null)
                        .WithMany("ContactDetails")
                        .HasForeignKey("UserEntityId");

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("DefaultTemplate.Domain.Common.Localizable", "Name", b1 =>
                        {
                            b1.Property<string>("PermissionEntityId")
                                .HasColumnType("text");

                            b1.Property<string>("En")
                                .HasColumnType("text");

                            b1.Property<string>("Kk")
                                .HasColumnType("text");

                            b1.Property<string>("Ru")
                                .HasColumnType("text");

                            b1.HasKey("PermissionEntityId");

                            b1.ToTable("Permissions", "portal");

                            b1.WithOwner()
                                .HasForeignKey("PermissionEntityId");
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RoleEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("DefaultTemplate.Domain.Common.Localizable", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("En")
                                .HasColumnType("text");

                            b1.Property<string>("Kk")
                                .HasColumnType("text");

                            b1.Property<string>("Ru")
                                .HasColumnType("text");

                            b1.HasKey("RoleEntityId");

                            b1.ToTable("Roles", "portal");

                            b1.WithOwner()
                                .HasForeignKey("RoleEntityId");
                        });

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RolePermissionEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", null)
                        .WithMany("Roles")
                        .HasForeignKey("PermissionEntityId");

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RoleEntity", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("DefaultTemplate.Domain.Common.Localizable", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("En")
                                .HasColumnType("text");

                            b1.Property<string>("Kk")
                                .HasColumnType("text");

                            b1.Property<string>("Ru")
                                .HasColumnType("text");

                            b1.HasKey("UserEntityId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityId");
                        });

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.WaiterEntity", b =>
                {
                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("DefaultTemplate.DataAccess.Entities.Users.WaiterEntity", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.PermissionEntity", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.RoleEntity", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("DefaultTemplate.DataAccess.Entities.Users.UserInfo.UserEntity", b =>
                {
                    b.Navigation("AddressDetails");

                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
