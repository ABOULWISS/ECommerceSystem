namespace ECommerceContractLair
{
    public class CartCustomerDTO
    {
        public CartCoreDTO Cart { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
    }
}
