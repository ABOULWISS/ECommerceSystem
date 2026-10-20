namespace ECommerceContractLair
{
    public enum ProductStatus
    {
        Available,
        OutOfStock,
        Discontinued
    }

    public class ProductCoreDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.OutOfStock;
        public string Image { get; set; } = string.Empty;
        public int CategoryID { get; set; }
    }
}
