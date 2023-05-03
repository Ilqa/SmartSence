namespace SmartSence.DTO
{
    public class BuildingDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public long Blockid { get; set; }
        public long OrgId { get; set; }
        public long SectorId { get; set; }

        public string Address { get; set; } = null!;

        public string Coordinates { get; set; } = null!;

        //public string Noofdevices { get; set; } = null!;

    }
}
