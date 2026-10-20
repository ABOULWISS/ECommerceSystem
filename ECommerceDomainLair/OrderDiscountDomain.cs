using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
     public class OrderDiscountDomain
    {

        [Key]
        [Required]
        public int OrderDiscountId { get; set; }




        [Required]
        [ForeignKey(nameof(OrderId) )]
        public int OrderId { get; set; }
        public OrderDomain Order { get; set; } = null!;



        [Required]
        [ForeignKey(nameof(DiscountId))]
        public int DiscountId { get; set; }
        public DiscountDomain Discount { get; set; } = null!;

    }
}
