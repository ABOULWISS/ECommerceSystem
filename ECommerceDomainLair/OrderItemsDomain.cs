using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ECommerceDomainLair
{
    public class OrderItemsDomain
    {
        [Key]
        [Required]
        public int OrderItemID { get; set; }



        [Required]
        public int Quantity { get; set; }


        [Required]
        public int OrderID { get; set; }




        [ForeignKey(nameof(OrderID))]
        [Required]
        public OrderDomain Order { get; set; } = null!;

        




        [Required]
        
        public int ProductID { get; set; }



        [ForeignKey(nameof(ProductID))]
        [Required]
        public ProductDomain Product { get; set; } =  null!;

    }
}
