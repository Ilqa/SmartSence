namespace SmartSence.DTO
{
    public class BlockDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public long Sectorid { get; set; }
        public long OrgId { get; set; }

        public string Logo { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Coordinates { get; set; } = null!;

        public string Noofgateways { get; set; } = null!;

        public string Noofdevices { get; set; } = null!;
    }
}
