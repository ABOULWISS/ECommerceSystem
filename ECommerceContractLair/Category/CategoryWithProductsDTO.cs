namespace ECommerceContractLair
{
    public class CategoryWithProductsDTO
    {
        public CategoryCoreDTO Category { get; set; } = null!;
        public ICollection<ProductCoreDTO> Products { get; set; } = new List<ProductCoreDTO>();
    }
}
