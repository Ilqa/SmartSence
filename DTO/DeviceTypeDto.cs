namespace SmartSence.DTO
{
    public class DeviceTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppEui { get; set; }
        public List<DeviceTypeColumnDto> DeviceTypeColumns { get; set; } = new();
    }

    public class DeviceTypeColumnDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}
