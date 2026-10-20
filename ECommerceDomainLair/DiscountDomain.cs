using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomainLair
{


    public enum DiscountType
    {
        Percentage,
        FixedAmount
    }



    public class DiscountDomain
    {
        [Key]
        [Required]
        public int DiscountID { get; set; }





        [Required]
        public string Code { get; set; } = string.Empty;



        [Required]
        public DiscountType Type { get; set; } 


        [Required]
        public int value { get; set; }


        [Required]
        public string Reason { get; set; } = string.Empty;



        [Required]
        public decimal MainOrderAmount { get; set; }





        [Required]
        public decimal MaxUses { get; set; }





        [Required]
        public decimal UsesCount { get; set; }


        [Required]
        public  DateTime validfrom { get; set; }



        [Required]
        public DateTime validTo { get; set; }





        [Required]
        public DateTime Created_at { get; set; }




        [Required]
        public bool IsActive { get; set; }



        public ICollection<CategoryDiscountDomain> CategoryDiscount { get; set; } = new List<CategoryDiscountDomain>();

        public ICollection<ProductDiscountDomain> ProductDiscount { get; set; } = new List<ProductDiscountDomain>();

        public ICollection<OrderDiscountDomain> OrderDiscount { get; set; } = new List<OrderDiscountDomain>();




    }
}
