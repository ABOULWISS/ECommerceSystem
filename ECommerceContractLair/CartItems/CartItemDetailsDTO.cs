namespace ECommerceContractLair
{
    public class CartItemDetailsDTO
    {
        public CartItemCoreDTO CartItem { get; set; } = null!;
        public CartCoreDTO Cart { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
