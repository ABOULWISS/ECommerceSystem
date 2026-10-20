using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{
    public class WishlistItemsDomain
    {
        [Key]
        public int WishListItemsId { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public int WishlistId { get; set; }
        [ForeignKey(nameof(WishlistId))]
        public WishListDomain Wishlist { get; set; } = null!;

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public ProductDomain Product { get; set; } = null!;
    }
}

