using SmartSence.Enums;

namespace SmartSence.DTO
{
    public class BuildingFloorDto
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

    }
}
