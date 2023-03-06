using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;

namespace SmartSence.Database;

public partial class SmartSenceContext : IdentityDbContext<User, UserRole, long>
{
    public SmartSenceContext()
    {
    }

    public SmartSenceContext(DbContextOptions<SmartSenceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Block> Blocks { get; set; }

    public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }

    public virtual DbSet<DeviceTelemetry> DeviceTelemetries { get; set; }

    public virtual DbSet<DeviceTelemetryJson> DeviceTelemetryJsons { get; set; }
    public virtual DbSet<Building> Houses { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=SmartSence;User Id=postgres;Password=floodee");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Block>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("block_pkey");

            entity.ToTable("block");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .HasColumnName("coordinates");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
          
            entity.Property(e => e.Sectorid).HasColumnName("sectorid");

            entity.HasOne(d => d.Sector).WithMany(p => p.Blocks)
                .HasForeignKey(d => d.Sectorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("block_sectorid_fkey");
        });

        modelBuilder.Entity<DeviceInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_info_pkey");

            entity.ToTable("device_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.DeviceEUI)
                .HasMaxLength(50)
                .HasColumnName("deviceeui");
            entity.Property(e => e.Devicetype)
                .HasMaxLength(50)
                .HasColumnName("devicetype");
           
         
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Orgid).HasColumnName("orgid");
            entity.Property(e => e.Serialnumber)
                .HasMaxLength(50)
                .HasColumnName("serialnumber");

          

            entity.HasOne(d => d.Org).WithMany(p => p.DeviceInfos)
                .HasForeignKey(d => d.Orgid)
                .HasConstraintName("deviceinfo_orgid_fkey");
        });

        modelBuilder.Entity<DeviceTelemetry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_telemetry_pkey");

            entity.ToTable("device_telemetry");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AppEui)
                .HasMaxLength(50)
                .HasColumnName("appeui");
            entity.Property(e => e.Time).HasColumnName("datetime");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Data)
                .HasMaxLength(50)
                .HasColumnName("msqjson");
            entity.Property(e => e.Port).HasColumnName("port");
            entity.Property(e => e.Seqno).HasColumnName("seqno");

            entity.HasOne(d => d.Device).WithMany(p => p.DeviceTelemetries)
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("device_telemetry_deviceid_fkey");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("house_pkey");

            entity.ToTable("house");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Blockid).HasColumnName("blockid");
          
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
         

            entity.HasOne(d => d.Block).WithMany(p => p.Houses)
                .HasForeignKey(d => d.Blockid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("house_blockid_fkey");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_pkey");

            entity.ToTable("organization");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .HasColumnName("coordinates");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Inventorydescription)
                .HasMaxLength(50)
                .HasColumnName("inventorydescription");
            entity.Property(e => e.Logo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Noofdevices)
                .HasMaxLength(50)
                .HasColumnName("noofdevices");
            entity.Property(e => e.Noofgateways)
                .HasMaxLength(50)
                .HasColumnName("noofgateways");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Webaddress)
                .HasMaxLength(50)
                .HasColumnName("webaddress");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sector_pkey");

            entity.ToTable("sector");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .HasColumnName("coordinates");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
           
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Networkdescription)
                .HasMaxLength(500)
                .HasColumnName("networkdescription");
           
            entity.Property(e => e.Orgid).HasColumnName("orgid");

            entity.HasOne(d => d.Org).WithMany(p => p.Sectors)
                .HasForeignKey(d => d.Orgid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sector_orgid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
