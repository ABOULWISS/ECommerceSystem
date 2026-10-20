namespace ECommerceContractLair
{
    public class CartItemCoreDTO
    {
        public int CartItemsID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int CartId { get; set; }
        public int ProductID { get; set; }
    }
}
