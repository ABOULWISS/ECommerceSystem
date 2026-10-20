using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{
    public class ShipmentTrackingDomain
    {
        [Key]
        public int ShipmentTrackingId { get; set; }

        public int ShipmentId { get; set; }
        [ForeignKey(nameof(ShipmentId))]
        public ShippingDomain Shipping { get; set; } = null!;

        [Required]
        public ShippingStatus Status { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime HappenedAt { get; set; }
    }
}
