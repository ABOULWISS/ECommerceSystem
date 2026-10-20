namespace ECommerceContractLair
{
    public class InventoryItemCoreDTO
    {
        public int InventoryItemsId { get; set; }
        public int QuantityAvailable { get; set; }
        public int QuantityReserved { get; set; }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
    }
}
