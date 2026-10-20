namespace ECommerceContractLair
{
    public class ShippingTrackingDetailsDTO
    {
        public ShippingTrackingCoreDTO ShippingTracking { get; set; } = null!;
        public ShippingCoreDTO Shipping { get; set; } = null!;
    }
}
