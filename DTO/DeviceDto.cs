using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;
using SmartSence.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSence.DTO
{
    public class DeviceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; } 

        public string Serialnumber { get; set; }

        public string DeviceEUI { get; set; } 

        public string Devicetype { get; set; } 

        public string Manufacturer { get; set; } 

        // public BitArray Isactive { get; set; }
        public StatusEnum Status { get; set; }

        public long? BuildingFloorId { get; set; }

        public long? Orgid { get; set; }
        
    }
}
