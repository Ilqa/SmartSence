using SmartSence.Databse.Entities;
using SmartSence.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Database.Entities
{
    public class Room
    {
        public long Id { get; set; }
       // public FloorEnum Floor { get; set; }
        public long BuildingFloorId { get; set; }

        [ForeignKey(nameof(BuildingFloorId))]
        public BuildingFloor BuildingFloor { get; set; }

        public virtual ICollection<DeviceInfo> DeviceInfos { get; } = new List<DeviceInfo>();
    }
}
