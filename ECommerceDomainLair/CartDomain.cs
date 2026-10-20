using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomainLair
{
    public class CartDomain
    {



        [Key]
        [Required]
        public int Cartid { get; set; }






        [Required]
        public DateTime CreatedAt { get; set; }



        [Required]
        public DateTime UpdatedAt { get; set; }



        [Required]
        public int CustomerID { get; set; }


        [ForeignKey(nameof(CustomerID))]

        public CustomerDomain Customer { get; set; } = null!;




   



        public ICollection<CartItemsDomain> CartItems { get; set; } = new List<CartItemsDomain>();




    }
}
