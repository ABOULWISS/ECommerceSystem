namespace ECommerceContractLair
{
    public class OrderItemDetailsDTO
    {
        public OrderItemCoreDTO OrderItem { get; set; } = null!;
        public OrderCoreDTO Order { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
