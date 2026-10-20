namespace ECommerceContractLair
{
    public enum OrderStatus
    {
        OrderCreated,
        OrderProcessing,
        OrderShipped,
        OrderDelivered,
        OrderCancelled,
    }

    public class OrderCoreDTO
    {
        public int OrderID { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string ShippingAddressSnapShot { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
    }
}
