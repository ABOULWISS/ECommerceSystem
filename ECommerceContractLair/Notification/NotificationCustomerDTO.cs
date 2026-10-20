namespace ECommerceContractLair
{
    public class NotificationCustomerDTO
    {
        public NotificationCoreDTO Notification { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
    }
}
