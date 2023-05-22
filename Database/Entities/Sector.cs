using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class Sector
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long Orgid { get; set; }

   // public string Logo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Coordinates { get; set; } = null!;

   // public string Noofgateways { get; set; } = null!;

   // public string Noofdevices { get; set; } = null!;

   // public string Networkdescription { get; set; } = null!;

    public virtual ICollection<Block> Blocks { get; } = new List<Block>();

    public virtual Organization Org { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
