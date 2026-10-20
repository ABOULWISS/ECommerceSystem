




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{
    public class CustomerDomain
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public CartDomain? Cart { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public UserDomain User { get; set; } = null!;

        public ICollection<AddressDomain> Addresses { get; set; } = new HashSet<AddressDomain>();

        public ICollection<NotificationDomain> Notifications { get; set; } = new List<NotificationDomain>();

        public ICollection<OrderDomain>  Orders { get; set; } = new List<OrderDomain>();

        
        
    }
}