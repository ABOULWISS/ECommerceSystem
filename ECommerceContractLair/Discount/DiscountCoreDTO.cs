namespace ECommerceContractLair
{
    public enum DiscountType
    {
        Percentage,
        FixedAmount
    }

    public class DiscountCoreDTO
    {
        public int DiscountID { get; set; }
        public string Code { get; set; } = string.Empty;
        public DiscountType Type { get; set; }
        public int Value { get; set; }
        public string Reason { get; set; } = string.Empty;
        public decimal MainOrderAmount { get; set; }
        public int MaxUses { get; set; }
        public int UsesCount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
    }
}
