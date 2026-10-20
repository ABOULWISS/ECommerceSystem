namespace ECommerceContractLair
{
    public class ProductDetailsDTO
    {
        public ProductCoreDTO Product { get; set; } = null!;
        public CategoryCoreDTO Category { get; set; } = null!;
        public ICollection<ProductDiscountCoreDTO> ProductDiscounts { get; set; } = new List<ProductDiscountCoreDTO>();
    }
}
