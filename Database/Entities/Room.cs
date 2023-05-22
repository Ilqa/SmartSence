using SmartSence.Databse.Entities;
using SmartSence.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Database.Entities
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long OrgId { get; set; }
        public long SectorId { get; set; }
        public long BlockId { get; set; }
        public long BuildingId { get; set; }

        public string Image { get; set; }

        public long BuildingFloorId { get; set; }

        [ForeignKey(nameof(BuildingFloorId))]
        public BuildingFloor BuildingFloor { get; set; }

        public virtual ICollection<Device> Devices { get; } = new List<Device>();

        public bool IsDeleted { get; set; }
    }
}
