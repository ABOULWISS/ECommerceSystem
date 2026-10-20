namespace ECommerceContractLair
{
    public class ShippingTrackingCoreDTO
    {
        public int ShipmentTrackingId { get; set; }
        public int ShipmentId { get; set; }
        public ShippingStatus Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime HappenedAt { get; set; }
    }
}
