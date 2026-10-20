using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
    public class ProductDiscountDomain
    {


        [Key]
        [Required]
        public int ProductDiscountId { get; set; }



        
        [Required]
        public int ProductId { get; set; }  


        [ForeignKey(nameof(ProductId))]
        public ProductDomain Product { get; set; } = null!;



        [Required]
        public int DiscountId { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public DiscountDomain Discount { get; set; } = null!;



    }
}
