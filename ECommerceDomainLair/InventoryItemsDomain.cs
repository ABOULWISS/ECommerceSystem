using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
    public class InventoryItemDomain
    {





        [Key]
        [Required]
        public int InventoryItemsId { get; set; }



        [Required]
        public int QuantityAvailable { get; set; }

        [Required]
        public int QuantityReserved { get; set; }


        [Required]
        public int InventoryId { get; set; }





        [ForeignKey(nameof(InventoryId))]
        public InventoryDomain Inventory { get; set; } = null!;





        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductDomain Product { get; set; } = null!;


    }
}
