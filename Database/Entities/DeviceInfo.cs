using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class DeviceInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Serialnumber { get; set; } = null!;

    public string Deviceeui { get; set; } = null!;

    public string Devicetype { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public BitArray Isactive { get; set; } = null!;

    public long? Orgid { get; set; }

    public long? Houseid { get; set; }

    public virtual ICollection<DeviceTelemetry> DeviceTelemetries { get; } = new List<DeviceTelemetry>();

    public virtual House? House { get; set; }

    public virtual Organization? Org { get; set; }
}
