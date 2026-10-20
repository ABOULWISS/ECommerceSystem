namespace ECommerceContractLair
{
    public class ShippingDetailsDTO
    {
        public ShippingCoreDTO Shipping { get; set; } = null!;
        public OrderCoreDTO Order { get; set; } = null!;
        public ICollection<ShippingTrackingCoreDTO> TrackingHistory { get; set; } = new List<ShippingTrackingCoreDTO>();
    }
}
