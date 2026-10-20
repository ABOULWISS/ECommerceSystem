namespace ECommerceContractLair
{
    public class DiscountDetailsDTO
    {
        public DiscountCoreDTO Discount { get; set; } = null!;
        public ICollection<CategoryDiscountCoreDTO> CategoryDiscounts { get; set; } = new List<CategoryDiscountCoreDTO>();
        public ICollection<ProductDiscountCoreDTO> ProductDiscounts { get; set; } = new List<ProductDiscountCoreDTO>();
        public ICollection<OrderDiscountCoreDTO> OrderDiscounts { get; set; } = new List<OrderDiscountCoreDTO>();
    }
}
