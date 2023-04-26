using SmartSence.Enums;

namespace SmartSence.DTO
{
    public class RoomDto
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

    }
}
