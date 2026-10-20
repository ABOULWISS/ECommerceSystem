using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDomainLair
{
    public class InventoryDomain
    {
        [Key]
        [Required]

        public int InventoryId { get; set; }

        [Required, MaxLength(150)]
        public string WarehouseLocation { get; set; } = string.Empty;

        public ICollection<InventoryItemDomain> InventoryItems { get; set; } = new List<InventoryItemDomain>();


    }
}
