using SmartSence.Enums;

namespace SmartSence.DTO
{
    public class GatewayDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string GatewayEUI { get; set; }
        public StatusEnum Status { get; set; }

        public long? Orgid { get; set; }
    }
}
