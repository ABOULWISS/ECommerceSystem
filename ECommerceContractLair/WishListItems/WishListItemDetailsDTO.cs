namespace ECommerceContractLair
{
    public class WishListItemDetailsDTO
    {
        public WishListItemCoreDTO WishListItem { get; set; } = null!;
        public WishListCoreDTO WishList { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
