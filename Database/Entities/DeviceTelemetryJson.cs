using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.Database.Entities
{
    public class DeviceTelemetryJson
    {
        public long Id { get; set; }
        public int DeviceId { get; set; }

        [Column(TypeName = "jsonb")]
        public string MsqJson { get; set; }
       // public JsonContent MsqJson { get; set; }
    }
}
