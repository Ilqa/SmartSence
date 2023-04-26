using SmartSence.Databse.Entities;
using SmartSence.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Database.Entities
{
    public class BuildingFloor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public FloorEnum Floor { get; set; }
        public long BuildingId { get; set; }
        public long Blockid { get; set; }
        public long OrgId { get; set; }
        public long SectorId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public Building Building { get; set; }

        public bool IsDeleted { get; set; }

        // public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();
    }
}
