using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerceDomainLair
{
    public class PermissionDomain
    {
        [Key]
        [Required]
        public int PermissionID { get; set; }
 
        // Naming convention: "Resource.Action" e.g. "Orders.Refund", "Products.Create", "Categories.Delete"
        [Required]
        public string PermissionName { get; set; } = string.Empty;
 
        public string? PermissionDescription { get; set; }
 
        [Required]
        public DateTime CreatedAt { get; set; }
 
        public ICollection<RolePermissionDomain> RolePermissions { get; set; } = new List<RolePermissionDomain>();

        public ICollection<UserPermissionDomain> UserPermissions { get; set; } = new List<UserPermissionDomain>();
    }
}
 