
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ECommerceDomainLair
{
 




   
    public class AddressDomain 
    {

        
        // ── Primary Key ──────────────────────────────────────────
        [Key]
        [Required]
        public int AddressId { get; set; }


        // ── Address Fields ───────────────────────────────────────
        [Required]
        [StringLength(255, MinimumLength = 5)] 
        [NoHtml]
        public string AddressLine1 { get; set; } = string.Empty;




        [StringLength(255)]
        [NoHtml]
        public string? AddressLine2 { get; set; }




        [Required]
        [StringLength(100, MinimumLength = 2)] 
        [NoHtml]
        public string City { get; set; } = string.Empty;




        [StringLength(100, MinimumLength = 2)]
        [NoHtml]
        public string? State { get; set; }




        [Required]
        [StringLength(100, MinimumLength = 2)]
        [NoHtml]
        public string Country { get; set; } = string.Empty;




        [StringLength(20)]
        [RegularExpression(@"^(?=.*[a-zA-Z0-9])[a-zA-Z0-9\s\-]{3,10}$",
            ErrorMessage = "Postal code must be 3–10 alphanumeric characters.")]
        public string? PostalCode { get; set; }




        // ── Flags ────────────────────────────────────────────────
        [Required]
        public bool IsDefault { get; set; } = false;




        public bool IsDeleted { get; set; } = false;


        public DateTime? DeletedAt { get; set; }




        // ── Audit Trail ──────────────────────────────────────────
        [Required]
        public DateTime CreatedAt { get; set; }



        public DateTime? UpdatedAt { get; set; }




 
        public int? LastModifiedByUserId { get; set; }




        // ── Foreign Keys + Navigation ────────────────────────────
        [Required]
        public int CustomerId { get; set; }




        [ForeignKey(nameof(CustomerId))]
        public CustomerDomain Customer { get; set; } = null!;




       
        public ICollection<OrderDomain> Orders { get; set; }
            = new HashSet<OrderDomain>();





        // ── Constructor ──────────────────────────────────────────
        public AddressDomain()
        {
            CreatedAt = DateTime.UtcNow;
        }




    }
}