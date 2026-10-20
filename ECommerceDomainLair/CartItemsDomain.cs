using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
    public class CartItemsDomain
    {

        [Key]
        [Required]
        public int CartItemsID { get; set; }



        [Required]
        public int Quantity { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }



        [Required]
        public decimal UnitPrice { get; set; }


        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public CartDomain Cart { get; set; } = null!;




        [Required]
        public int  ProductID { get; set; }



        [ForeignKey(nameof(ProductID))]
        public ProductDomain Product { get; set;} = null!;


    }
}
