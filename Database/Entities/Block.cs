using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class Block
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long Sectorid { get; set; }

    public string Logo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Coordinates { get; set; } = null!;

    public string Noofgateways { get; set; } = null!;

    public string Noofdevices { get; set; } = null!;

    public virtual ICollection<House> Houses { get; } = new List<House>();

   
    public virtual Sector Sector { get; set; } = null!;
}
