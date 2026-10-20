namespace ECommerceContractLair
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

    public class ShippingCoreDTO
    {
        public int ShippingId { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public decimal ShippingCost { get; set; }
        public string? CarrierName { get; set; }
        public ShippingMethod Method { get; set; } = ShippingMethod.Standard;
        public DateTime EstimatedDeliveryDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public int OrderId { get; set; }
       
    }
}
