
using SmartSence.Databse.Entities;
using SmartSence.Enums;

namespace SmartSence.Database.Entities
{
    public class Gateway
    {
        public long Id { get; set; }    
        public string Name { get; set; }    
        public string GatewayEUI { get; set; }
        public StatusEnum Status { get; set; }

        public long? Orgid { get; set; }
        public virtual Organization? Org { get; set; }

        public bool IsDeleted { get; set; }
    }
}
