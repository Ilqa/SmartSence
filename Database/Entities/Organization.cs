using SmartSence.Database.Entities;
using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class Organization
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Coordinates { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Noofgateways { get; set; } = null!;

    public string Noofdevices { get; set; } = null!;

    public string Inventorydescription { get; set; } = null!;

    public string Webaddress { get; set; } = null!;

    public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();

    public virtual ICollection<Gateway> Gateways { get; } = new List<Gateway>();

    public virtual ICollection<Sector> Sectors { get; } = new List<Sector>();
}
