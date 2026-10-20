namespace ECommerceContractLair
{
    public class CartItemProductDTO
    {
        public CartItemCoreDTO CartItem { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
