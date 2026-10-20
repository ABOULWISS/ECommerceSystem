using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDomainLair
{
    public class RoleDomain
    {
        [Key]
        [Required]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty; // e.g. "Admin", "Vendor", "SupportAgent", "Customer"

        public string? RoleDescription { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Join entities (many-to-many via explicit join tables)
        public ICollection<UserRoleDomain> UserRoles { get; set; } = new List<UserRoleDomain>();

        public ICollection<RolePermissionDomain> RolePermissions { get; set; } = new List<RolePermissionDomain>();
    }
}