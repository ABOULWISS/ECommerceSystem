using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
    public class CategoryDiscountDomain
    {


        [Key]
        [Required]
        public int CategoryDiscountId { get; set; }




        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public CategoryDomain Category { get; set; } = null!;



        [Required]
        [ForeignKey(nameof(DiscountId))]
        public int DiscountId { get; set; }
        public DiscountDomain Discount { get; set; } = null!;


    }
}
