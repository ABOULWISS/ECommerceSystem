using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceDomainLair
{
    public class CategoryDomain
    {

        [Key]
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string CategoryDescription { get; set; } = string.Empty;


        
        public int? ParentCategoryID { get; set; } 


        [ForeignKey("ParentCategoryID")]
        public CategoryDomain? ParentCategory { get; set; }



        public ICollection<CategoryDomain> SubCategories { get; set; } = new List<CategoryDomain>();




        [Required]
        public DateTime CreatedAt { get; set; }


        
        public DateTime  UpdatedAt { get; set; }


        public ICollection<ProductDomain> Products { get; set; } = new List<ProductDomain>();


        public ICollection<CategoryDiscountDomain> CategoryDiscount { get; set; } = new List<CategoryDiscountDomain>();


    }
}
