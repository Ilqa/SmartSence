using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using SmartSence.Enums;
using System.Text.Json.Serialization;

namespace SmartSence.DTO
{
    public class GatewayDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string GatewayEUI { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        public StatusEnum Status { get; set; }

        public long? Orgid { get; set; }
    }
}
