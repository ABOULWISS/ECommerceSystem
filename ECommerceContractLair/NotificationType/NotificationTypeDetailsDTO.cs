namespace ECommerceContractLair
{
    public class NotificationTypeDetailsDTO
    {
        public NotificationTypeCoreDTO NotificationType { get; set; } = null!;
        public ICollection<NotificationCoreDTO> Notifications { get; set; } = new List<NotificationCoreDTO>();
    }
}
