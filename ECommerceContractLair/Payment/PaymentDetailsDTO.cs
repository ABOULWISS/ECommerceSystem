namespace ECommerceContractLair
{
    public class PaymentDetailsDTO
    {
        public PaymentCoreDTO Payment { get; set; } = null!;
        public OrderCoreDTO Order { get; set; } = null!;
    }
}
