namespace ECommerceContractLair
{
    public class DiscountCategoryDTO
    {
        public DiscountCoreDTO Discount { get; set; } = null!;
        public ICollection<CategoryDiscountCoreDTO> CategoryDiscounts { get; set; } = new List<CategoryDiscountCoreDTO>();
    }
}
