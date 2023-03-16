using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class DeviceTelemetry
{
    public int Id { get; set; }

    public long Seqno { get; set; }

    public string AppEui { get; set; } = null!;

    public DateTime Time { get; set; }

    public int Port { get; set; }

    public string Data { get; set; } = null!;

    public int? Deviceid { get; set; }

    public string DeviceType { get; set; }

    public virtual DeviceInfo? Device { get; set; }

    public string DeviceEui { get; set; }

    public string DeviceTx { get; set; } 

    public string GatewayRx { get; set; } 
}
