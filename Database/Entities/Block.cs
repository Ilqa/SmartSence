using System;
using System.Collections.Generic;

namespace SmartSence.Databse.Entities;

public partial class Block
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long Sectorid { get; set; }
    public long OrgId { get; set; }

    public string Address { get; set; } = null!;

    public string Coordinates { get; set; } = null!;

    public virtual ICollection<Building> Houses { get; } = new List<Building>();  
    public virtual Sector Sector { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
