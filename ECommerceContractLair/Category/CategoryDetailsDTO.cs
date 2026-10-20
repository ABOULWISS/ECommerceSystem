namespace ECommerceContractLair
{
    public class CategoryDetailsDTO
    {
        public CategoryCoreDTO Category { get; set; } = null!;
        public ICollection<ProductCoreDTO> Products { get; set; } = new List<ProductCoreDTO>();
        public ICollection<CategoryDiscountCoreDTO> CategoryDiscounts { get; set; } = new List<CategoryDiscountCoreDTO>();
    }
}
