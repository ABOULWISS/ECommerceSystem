namespace ECommerceContractLair
{
    public class WishListDetailsDTO
    {
        public WishListCoreDTO WishList { get; set; } = null!;
        public CustomerCoreDTO Customer { get; set; } = null!;
        public ICollection<WishListItemCoreDTO> Items { get; set; } = new List<WishListItemCoreDTO>();
    }
}
