using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{
    public class WishListDomain
    {
        [Key]
        public int WishListId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerDomain Customer { get; set; } = null!;


        public ICollection<WishlistItemsDomain> Items { get; set; } = new List<WishlistItemsDomain>();
    }
}