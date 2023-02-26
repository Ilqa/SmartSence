using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class DeviceTelemetry
{
    public int Id { get; set; }

    public long Seqno { get; set; }

    public string Appeui { get; set; } = null!;

    public DateOnly Datetime { get; set; }

    public int Port { get; set; }

    public string Msqjson { get; set; } = null!;

    public int? Deviceid { get; set; }

    public virtual DeviceInfo? Device { get; set; }
}
