using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDomainLair
{


    public class UserDomain
    {
        [Key]
        public int UserID { get; set; }


        [Required]
        [MaxLength(256)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(256)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public CustomerDomain? Customer { get; set; }


        public ICollection<UserRoleDomain> UserRoles { get; set; } = new List<UserRoleDomain>();

        public ICollection<UserPermissionDomain> UserPermissions { get; set; } = new List<UserPermissionDomain>();

    }
}