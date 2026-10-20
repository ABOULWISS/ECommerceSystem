namespace ECommerceContractLair
{
    public class OrderDiscountDetailsDTO
    {
        public OrderDiscountCoreDTO OrderDiscount { get; set; } = null!;
        public OrderCoreDTO Order { get; set; } = null!;
        public DiscountCoreDTO Discount { get; set; } = null!;
    }
}
