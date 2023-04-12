namespace SmartSence.Database.Entities
{
    public class DeviceType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppEui { get; set; }

        public string TelemetryDBName { get; set; }
        public List<DeviceTypeMetaData> DeviceTypeColumns { get; set; } = new();
    }

    public class DeviceTypeMetaData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set;}
        public int Sequence { get; set; }
    }
}
