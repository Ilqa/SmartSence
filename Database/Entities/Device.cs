﻿using SmartSence.Database.Entities;

using SmartSence.Enums;
using SmartSence.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Databse.Entities;

public partial class Device
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Serialnumber { get; set; } = null!;

    public string DeviceEUI { get; set; } = null!;

    public Database.Entities.DeviceType Devicetype { get; set; }

    public long DeviceTypeId { get; set; }

    public string Manufacturer { get; set; } = null!;

    // public BitArray Isactive { get; set; }
    public StatusEnum Status { get; set; }
    public long? Orgid { get; set; }
    public long? SectorId { get; set; }
    public long? BlockId { get; set; }
    public long? BuildingId { get; set; }
    
    public long? BuildingFloorId { get; set; }
    public long? RoomId { get; set; }

    public virtual ICollection<DeviceTelemetry> DeviceTelemetries { get; } = new List<DeviceTelemetry>();

    [ForeignKey(nameof(RoomId))]
    public virtual Room? Room { get; set; }

    
    public virtual Organization? Org { get; set; }

    public bool IsDeleted { get; set; }


}
