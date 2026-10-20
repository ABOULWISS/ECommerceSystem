namespace ECommerceContractLair
{
    public class ProductDiscountDetailsDTO
    {
        public ProductDiscountCoreDTO ProductDiscount { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
        public DiscountCoreDTO Discount { get; set; } = null!;
    }
}
