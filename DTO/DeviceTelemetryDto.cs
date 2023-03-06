using SmartSence.Databse.Entities;

namespace SmartSence.DTO
{
    public class DeviceTelemetryDto
    {
        public int Id { get; set; }

        public long Seqno { get; set; }

        public string AppEui { get; set; } = null!;

        public DateTime Time { get; set; }

        public int Port { get; set; }

        public object Data { get; set; }

        public string DeviceEui { get; set; }

        public object DeviceTx { get; set; }

        public object GatewayRx { get; set; }
    }
}
