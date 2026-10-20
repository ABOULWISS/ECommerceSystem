namespace ECommerceContractLair
{
    public class DiscountOrderDTO
    {
        public DiscountCoreDTO Discount { get; set; } = null!;
        public ICollection<OrderDiscountCoreDTO> OrderDiscounts { get; set; } = new List<OrderDiscountCoreDTO>();
    }
}
