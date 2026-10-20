namespace ECommerceContractLair
{
    public class CategoryDiscountDetailsDTO
    {
        public CategoryDiscountCoreDTO CategoryDiscount { get; set; } = null!;
        public CategoryCoreDTO Category { get; set; } = null!;
        public DiscountCoreDTO Discount { get; set; } = null!;
    }
}
