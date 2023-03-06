﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartSence.Database;

#nullable disable

namespace SmartSence.Migrations
{
    [DbContext(typeof(SmartSenceContext))]
    partial class SmartSenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SmartSence.Database.Entities.BuildingFloor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BuildingId")
                        .HasColumnType("bigint");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("BuildingFloor");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.DeviceTelemetryJson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<string>("MsqJson")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("DeviceTelemetryJsons");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.Gateway", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("GatewayEUI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("Orgid")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Orgid");

                    b.ToTable("Gateway");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<long?>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("OrganizationId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SmartSence.Database.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Block", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("coordinates");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<long>("Sectorid")
                        .HasColumnType("bigint")
                        .HasColumnName("sectorid");

                    b.HasKey("Id")
                        .HasName("block_pkey");

                    b.HasIndex("Sectorid");

                    b.ToTable("block", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<long>("Blockid")
                        .HasColumnType("bigint")
                        .HasColumnName("blockid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("house_pkey");

                    b.HasIndex("Blockid");

                    b.ToTable("house", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.DeviceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("BuildingFloorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("DeviceEUI")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("deviceeui");

                    b.Property<string>("Devicetype")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("devicetype");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("manufacturer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<long?>("Orgid")
                        .HasColumnType("bigint")
                        .HasColumnName("orgid");

                    b.Property<string>("Serialnumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("serialnumber");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("device_info_pkey");

                    b.HasIndex("BuildingFloorId");

                    b.HasIndex("Orgid");

                    b.ToTable("device_info", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.DeviceTelemetry", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Appeui")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("appeui");

                    b.Property<DateOnly>("Datetime")
                        .HasColumnType("date")
                        .HasColumnName("datetime");

                    b.Property<int?>("Deviceid")
                        .HasColumnType("integer")
                        .HasColumnName("deviceid");

                    b.Property<string>("Msqjson")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("msqjson");

                    b.Property<int>("Port")
                        .HasColumnType("integer")
                        .HasColumnName("port");

                    b.Property<long>("Seqno")
                        .HasColumnType("bigint")
                        .HasColumnName("seqno");

                    b.HasKey("Id")
                        .HasName("device_telemetry_pkey");

                    b.HasIndex("Deviceid");

                    b.ToTable("device_telemetry", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("coordinates");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Inventorydescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("inventorydescription");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("logo")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("Noofdevices")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("noofdevices");

                    b.Property<string>("Noofgateways")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("noofgateways");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("phone");

                    b.Property<string>("Webaddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("webaddress");

                    b.HasKey("Id")
                        .HasName("organization_pkey");

                    b.ToTable("organization", (string)null);
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Sector", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("coordinates");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("Networkdescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("networkdescription");

                    b.Property<long>("Orgid")
                        .HasColumnType("bigint")
                        .HasColumnName("orgid");

                    b.HasKey("Id")
                        .HasName("sector_pkey");

                    b.HasIndex("Orgid");

                    b.ToTable("sector", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSence.Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSence.Database.Entities.BuildingFloor", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.Gateway", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Organization", "Org")
                        .WithMany("Gateways")
                        .HasForeignKey("Orgid");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.User", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Block", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Sector", "Sector")
                        .WithMany("Blocks")
                        .HasForeignKey("Sectorid")
                        .IsRequired()
                        .HasConstraintName("block_sectorid_fkey");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Building", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Block", "Block")
                        .WithMany("Houses")
                        .HasForeignKey("Blockid")
                        .IsRequired()
                        .HasConstraintName("house_blockid_fkey");

                    b.Navigation("Block");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.DeviceInfo", b =>
                {
                    b.HasOne("SmartSence.Database.Entities.BuildingFloor", "BuildingFloor")
                        .WithMany("DeviceInfos")
                        .HasForeignKey("BuildingFloorId");

                    b.HasOne("SmartSence.Databse.Entities.Organization", "Org")
                        .WithMany("DeviceInfos")
                        .HasForeignKey("Orgid")
                        .HasConstraintName("deviceinfo_orgid_fkey");

                    b.Navigation("BuildingFloor");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.DeviceTelemetry", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.DeviceInfo", "Device")
                        .WithMany("DeviceTelemetries")
                        .HasForeignKey("Deviceid")
                        .HasConstraintName("device_telemetry_deviceid_fkey");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Sector", b =>
                {
                    b.HasOne("SmartSence.Databse.Entities.Organization", "Org")
                        .WithMany("Sectors")
                        .HasForeignKey("Orgid")
                        .IsRequired()
                        .HasConstraintName("sector_orgid_fkey");

                    b.Navigation("Org");
                });

            modelBuilder.Entity("SmartSence.Database.Entities.BuildingFloor", b =>
                {
                    b.Navigation("DeviceInfos");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Block", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.DeviceInfo", b =>
                {
                    b.Navigation("DeviceTelemetries");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Organization", b =>
                {
                    b.Navigation("DeviceInfos");

                    b.Navigation("Gateways");

                    b.Navigation("Sectors");
                });

            modelBuilder.Entity("SmartSence.Databse.Entities.Sector", b =>
                {
                    b.Navigation("Blocks");
                });
#pragma warning restore 612, 618
        }
    }
}
