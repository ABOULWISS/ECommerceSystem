




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{
    public enum ShippingStatus
    {
        Pending,
        Shipped,
        InTransit,
        OutForDelivery,
        Delivered,
        Failed,
        Returned
    }

    public enum ShippingMethod
    {
        Standard,
        Express,
        Overnight,
        SameDay,
        Pickup
    }

    public class ShippingDomain
    {
        [Key]
        public int ShippingId { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\-]{5,100}$",
            ErrorMessage = "Tracking number must be 5–100 alphanumeric characters.")]
        public string TrackingNumber { get; set; } = string.Empty;

        [Required]
        [Range(0, 99999.99,
            ErrorMessage = "Shipping cost must be between 0 and 99,999.99.")]
        public decimal ShippingCost { get; set; }

        [MaxLength(100)]
        public string? CarrierName { get; set; }

        public ShippingMethod Method { get; set; } = ShippingMethod.Standard;

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int? LastModifiedByUserId { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public OrderDomain Order { get; set; } = null!;



        public ICollection<ShipmentTrackingDomain> TrackingHistory { get; set; } = new HashSet<ShipmentTrackingDomain>();
    }
}