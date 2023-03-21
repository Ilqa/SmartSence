namespace SmartSence.DTO
{
    public class DashboardSummary
    {
        public string EntityType { get; set; }  // Gateway, Device, User
        public int OnlineEntites { get; set; }
        public int OfflineEntities { get; set; }
    }
}
