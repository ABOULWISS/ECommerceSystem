using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerceDomainLair
{


    public enum ProductStatus
    {
        Available,
        OutOfStock,
        Discontinued
    }



    public class ProductDomain
    {
        [Key]
        [Required]
        public int ProductID { get; set; }



        [MaxLength(150)]
        [Required]
        public string ProductName { get; set; } = string.Empty;


        [Required]
        [MaxLength(1000)]
        public string ProductDescription { get; set; } = string.Empty;


        [Required]
        public decimal Price { get; set; }







        public ProductStatus Status { get; set; } = ProductStatus.OutOfStock;




        [MaxLength(500)]
        public string Image { get; set; } = string.Empty;





        
        [Required]
        public int CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public CategoryDomain Category { get; set; } = null!;




        public ICollection<CartItemsDomain> CartItems { get; set; }
        = new HashSet<CartItemsDomain>();

        public ICollection<ProductDiscountDomain> ProductDiscount { get; set; } = new List<ProductDiscountDomain>();


        public ICollection<OrderItemsDomain> OrderItems { get; set; } = new HashSet<OrderItemsDomain>();

        public ICollection<InventoryItemDomain> InventoryItems { get; set; } = new HashSet<InventoryItemDomain>();





    }
}
