namespace ECommerceContractLair
{
    public class OrderDetailsDTO
    {
        public OrderCoreDTO Order { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
        public AddressCoreDTO Address { get; set; } = null!;
        public ICollection<OrderItemCoreDTO> Items { get; set; } = new List<OrderItemCoreDTO>();
        public ICollection<OrderDiscountCoreDTO> OrderDiscounts { get; set; } = new List<OrderDiscountCoreDTO>();
        public ICollection<PaymentCoreDTO> Payments { get; set; } = new List<PaymentCoreDTO>();
    }
}
