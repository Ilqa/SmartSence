namespace SmartSence.DTO
{
    public class SectorDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public long Orgid { get; set; }

        public string Logo { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Coordinates { get; set; } = null!;

        public string Noofgateways { get; set; } = null!;

        public string Noofdevices { get; set; } = null!;

        public string Networkdescription { get; set; } = null!;
    }
}
