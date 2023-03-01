using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class Building
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long Blockid { get; set; }

    public string Address { get; set; } = null!;

    //public string Coordinates { get; set; } = null!;

    //public string Noofdevices { get; set; } = null!;

    public virtual Block Block { get; set; } = null!;

   // public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();
}
