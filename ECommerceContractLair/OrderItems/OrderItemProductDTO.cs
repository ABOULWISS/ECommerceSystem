namespace ECommerceContractLair
{
    public class OrderItemProductDTO
    {
        public OrderItemCoreDTO OrderItem { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
