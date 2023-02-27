namespace SmartSence.DTO
{
    public class HouseDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public long Blockid { get; set; }

        public string Address { get; set; } = null!;

        public string Coordinates { get; set; } = null!;

        public string Noofdevices { get; set; } = null!;

        public long BlockId { get; set; }
    }
}
