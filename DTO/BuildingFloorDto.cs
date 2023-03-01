using SmartSence.Enums;

namespace SmartSence.DTO
{
    public class BuildingFloorDto
    {
        public long Id { get; set; }
        public FloorEnum Floor { get; set; }
        public long BuildingId { get; set; }

    }
}
