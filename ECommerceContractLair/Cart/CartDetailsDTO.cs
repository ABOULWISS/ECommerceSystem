namespace ECommerceContractLair
{
    public class CartDetailsDTO
    {
        public CartCoreDTO Cart { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
        public ICollection<CartItemCoreDTO> Items { get; set; } = new List<CartItemCoreDTO>();
    }
}
