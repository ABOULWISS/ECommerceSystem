namespace ECommerceContractLair
{
    public class CategoryCoreDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;
        public int ? ParentCategoryID { get; set; }  
    }
}
