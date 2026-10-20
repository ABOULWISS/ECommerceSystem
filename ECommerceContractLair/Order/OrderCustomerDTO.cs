namespace ECommerceContractLair
{
    public class OrderCustomerDTO
    {
        public OrderCoreDTO Order { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
    }
}
