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

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceTelemetry> DeviceTelemetries { get; set; }

    public virtual DbSet<DeviceTelemetryJson> DeviceTelemetryJsons { get; set; }
    public virtual DbSet<Building> Building { get; set; }
    public virtual DbSet<BuildingFloor> BuildingFloors { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<DeviceType> DeviceTypes { get; set; }

    public virtual DbSet<DeviceTypeMetaData> DeviceTypeMetaData { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseNpgsql("Host=localhost;Database=SmartSence;User Id=postgres;Password=floodee");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
