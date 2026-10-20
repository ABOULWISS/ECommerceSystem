namespace ECommerceContractLair
{
    public class NotificationDetailsDTO
    {
        public NotificationCoreDTO Notification { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
        public NotificationTypeCoreDTO NotificationType { get; set; } = null!;
    }
}
