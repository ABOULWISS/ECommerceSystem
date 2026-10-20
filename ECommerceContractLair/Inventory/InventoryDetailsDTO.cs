namespace ECommerceContractLair
{
    public class InventoryDetailsDTO
    {
        public InventoryCoreDTO Inventory { get; set; } = null!;
        public ICollection<InventoryItemCoreDTO> InventoryItems { get; set; } = new List<InventoryItemCoreDTO>();
    }
}
