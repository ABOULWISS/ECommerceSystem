namespace ECommerceContractLair
{
    public class InventoryItemDetailsDTO
    {
        public InventoryItemCoreDTO InventoryItem { get; set; } = null!;
        public InventoryCoreDTO Inventory { get; set; } = null!;
        public ProductCoreDTO Product { get; set; } = null!;
    }
}
