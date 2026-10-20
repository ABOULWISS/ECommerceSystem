namespace ECommerceContractLair
{
    public class DiscountProductDTO
    {
        public DiscountCoreDTO Discount { get; set; } = null!;
        public ICollection<ProductDiscountCoreDTO> ProductDiscounts { get; set; } = new List<ProductDiscountCoreDTO>();
    }
}
