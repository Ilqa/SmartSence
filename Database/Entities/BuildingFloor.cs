using SmartSence.Databse.Entities;
using SmartSence.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Database.Entities
{
    public class BuildingFloor
    {
        public long Id { get; set; }
        public FloorEnum Floor { get; set; }
        public long BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public Building Building { get; set; }

        public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();
    }
}
