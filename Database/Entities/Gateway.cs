
using SmartSence.Enums;

namespace SmartSence.Database.Entities
{
    public class Gateway
    {
        public long Id { get; set; }    
        public string Name { get; set; }    
        public string GatewayEUI { get; set; }
        public StatusEnum Status { get; set; }
    }
}
