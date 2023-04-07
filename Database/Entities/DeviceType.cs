namespace SmartSence.Database.Entities
{
    public class DeviceType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppEui { get; set; }
        public List<DeviceTypeColumn> DeviceTypeColumns { get; set; } = new();
    }

    public class DeviceTypeColumn
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set;}
    }
}
