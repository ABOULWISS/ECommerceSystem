namespace ECommerceContractLair
{
    public class NotificationCoreDTO
    {
        public int NotificationId { get; set; }
        public string DynamicData { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public int CustomerId { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
